"""Generate a PDF/AcroForm sample containing every common form field type.

Pure standard library - no PDF library, no evaluation watermark, no licence.
Produces a single-page Letter document with labelled, bordered fields.
"""

import sys
import zlib

W, H = 612, 792
LX, FX, FW = 56, 224, 300          # label x, field x, default field width
ROW_GAP = 14

objects = {}
_next = [1]


def alloc():
    n = _next[0]
    _next[0] += 1
    return n


def put(num, payload):
    objects[num] = payload.encode("latin-1") if isinstance(payload, str) else payload


def esc(s):
    return s.replace("\\", r"\\").replace("(", r"\(").replace(")", r"\)")


def stream_obj(num, dict_body, data):
    """Store a stream object. Streams are Flate-compressed: besides being smaller,
    the compressed bytes contain NULs, so Git reliably detects the PDF as binary and
    never applies CRLF translation to it (which would invalidate the xref offsets)."""
    data = data.encode("latin-1") if isinstance(data, str) else data
    data = zlib.compress(data, 9)
    head = "<< %s /Filter /FlateDecode /Length %d >>\nstream\n" % (dict_body, len(data))
    put(num, head.encode("latin-1") + data + b"\nendstream")


catalog, pages, page, content = alloc(), alloc(), alloc(), alloc()
helv, zadb = alloc(), alloc()

put(helv, "<< /Type /Font /Subtype /Type1 /BaseFont /Helvetica /Encoding /WinAnsiEncoding >>")
put(zadb, "<< /Type /Font /Subtype /Type1 /BaseFont /ZapfDingbats >>")

fields, annots, labels = [], [], []


def label(x, y, text, size=10):
    labels.append((x, y, size, text))


def frame(w, h, bg="0.97 0.97 0.97"):
    """Background + border operators shared by every field appearance."""
    return ("q %s rg 0 0 %g %g re f Q\n"
            "q 0.45 0.45 0.45 RG 0.7 w 0.35 0.35 %g %g re S Q\n" % (bg, w, h, w - 0.7, h - 0.7))


# ------------------------------------------------------------------ appearances
def text_ap(num, w, h, value, size=10, multiline=False):
    body = [frame(w, h), "/Tx BMC", "q", "BT", "/Helv %d Tf" % size, "0 g"]
    if multiline:
        body.append("4 %g Td" % (h - size - 4))
        for i, ln in enumerate(value.split("\n")):
            if i:
                body.append("0 %g Td" % (-(size + 3)))
            body.append("(%s) Tj" % esc(ln))
    else:
        body.append("4 %g Td" % ((h - size) / 2 + 1.5))
        body.append("(%s) Tj" % esc(value))
    body += ["ET", "Q", "EMC"]
    stream_obj(num,
               "/Type /XObject /Subtype /Form /BBox [0 0 %g %g] "
               "/Resources << /Font << /Helv %d 0 R >> >>" % (w, h, helv),
               "\n".join(body))


def toggle_ap(on_num, off_num, box, glyph, round_bg=False):
    bg = "1 1 1"
    stream_obj(on_num,
               "/Type /XObject /Subtype /Form /BBox [0 0 %g %g] "
               "/Resources << /Font << /ZaDb %d 0 R >> >>" % (box, box, zadb),
               frame(box, box, bg) + "q 0 g BT /ZaDb %g Tf 2 3 Td (%s) Tj ET Q" % (box - 4, glyph))
    stream_obj(off_num,
               "/Type /XObject /Subtype /Form /BBox [0 0 %g %g] /Resources << >>" % (box, box),
               frame(box, box, bg))


# ---------------------------------------------------------------------- fields
def add_text(name, value, y, shown=None, h=20, w=FW, flags=0, multiline=False):
    num, ap = alloc(), alloc()
    text_ap(ap, w, h, value if shown is None else shown, 10, multiline)
    put(num,
        "<< /Type /Annot /Subtype /Widget /FT /Tx /T (%s) /V (%s) /Ff %d "
        "/DA (/Helv 10 Tf 0 g) /Rect [%g %g %g %g] /F 4 /P %d 0 R "
        "/MK << /BC [0.45 0.45 0.45] /BG [0.97 0.97 0.97] >> /AP << /N %d 0 R >> >>"
        % (esc(name), esc(value), flags, FX, y, FX + w, y + h, page, ap))
    fields.append(num)
    annots.append(num)


def add_checkbox(name, y, checked, box=13):
    num, on, off = alloc(), alloc(), alloc()
    toggle_ap(on, off, box, "4")                       # ZapfDingbats 4 = check mark
    state = "/Yes" if checked else "/Off"
    put(num,
        "<< /Type /Annot /Subtype /Widget /FT /Btn /T (%s) /V %s /AS %s "
        "/DA (/ZaDb 0 Tf 0 g) /Rect [%g %g %g %g] /F 4 /P %d 0 R "
        "/MK << /BC [0.45 0.45 0.45] /BG [1 1 1] /CA (4) >> "
        "/AP << /N << /Yes %d 0 R /Off %d 0 R >> >> >>"
        % (esc(name), state, state, FX, y, FX + box, y + box, page, on, off))
    fields.append(num)
    annots.append(num)


def add_radio(name, options, selected, y, box=13, gap=95):
    parent = alloc()
    kids = []
    for i, opt in enumerate(options):
        kid, on, off = alloc(), alloc(), alloc()
        toggle_ap(on, off, box, "l")                   # ZapfDingbats l = filled circle
        x = FX + i * gap
        state = "/" + opt if opt == selected else "/Off"
        put(kid,
            "<< /Type /Annot /Subtype /Widget /Parent %d 0 R /AS %s "
            "/Rect [%g %g %g %g] /F 4 /P %d 0 R "
            "/MK << /BC [0.45 0.45 0.45] /BG [1 1 1] /CA (l) >> "
            "/AP << /N << /%s %d 0 R /Off %d 0 R >> >> >>"
            % (parent, state, x, y, x + box, y + box, page, opt, on, off))
        kids.append(kid)
        annots.append(kid)
        label(x + box + 6, y + 3, opt, 9)
    put(parent,                                        # 49152 = Radio + NoToggleToOff
        "<< /FT /Btn /Ff 49152 /T (%s) /V /%s /Kids [%s] >>"
        % (esc(name), selected, " ".join("%d 0 R" % k for k in kids)))
    fields.append(parent)


def add_choice(name, options, y, flags, value=None, values=None, h=20, w=FW):
    num, ap = alloc(), alloc()
    text_ap(ap, w, h, value if values is None else "\n".join(values), 10, values is not None)
    v = ("/V (%s)" % esc(value)) if values is None else \
        ("/V [%s]" % " ".join("(%s)" % esc(o) for o in values))
    put(num,
        "<< /Type /Annot /Subtype /Widget /FT /Ch /T (%s) %s /Ff %d /Opt [%s] "
        "/DA (/Helv 10 Tf 0 g) /Rect [%g %g %g %g] /F 4 /P %d 0 R "
        "/MK << /BC [0.45 0.45 0.45] /BG [0.97 0.97 0.97] >> /AP << /N %d 0 R >> >>"
        % (esc(name), v, flags, " ".join("(%s)" % esc(o) for o in options),
           FX, y, FX + w, y + h, page, ap))
    fields.append(num)
    annots.append(num)


def add_signature(name, y, h=38, w=200):
    num, ap = alloc(), alloc()
    stream_obj(ap,
               "/Type /XObject /Subtype /Form /BBox [0 0 %g %g] "
               "/Resources << /Font << /Helv %d 0 R >> >>" % (w, h, helv),
               frame(w, h, "1 1 0.94") +
               "q 0.55 0.55 0.55 rg BT /Helv 8 Tf 5 5 Td (not signed) Tj ET Q")
    put(num,
        "<< /Type /Annot /Subtype /Widget /FT /Sig /T (%s) "
        "/Rect [%g %g %g %g] /F 4 /P %d 0 R "
        "/MK << /BC [0.45 0.45 0.45] /BG [1 1 0.94] >> /AP << /N %d 0 R >> >>"
        % (esc(name), FX, y, FX + w, y + h, page, ap))
    fields.append(num)
    annots.append(num)


def add_button(name, caption, y, h=22, w=95):
    num, ap = alloc(), alloc()
    stream_obj(ap,
               "/Type /XObject /Subtype /Form /BBox [0 0 %g %g] "
               "/Resources << /Font << /Helv %d 0 R >> >>" % (w, h, helv),
               frame(w, h, "0.85 0.85 0.85") +
               "q BT /Helv 10 Tf 0 g %g %g Td (%s) Tj ET Q"
               % ((w - len(caption) * 5.3) / 2, (h - 10) / 2 + 1.5, esc(caption)))
    put(num,                                           # 65536 = Pushbutton
        "<< /Type /Annot /Subtype /Widget /FT /Btn /Ff 65536 /T (%s) "
        "/Rect [%g %g %g %g] /F 4 /P %d 0 R "
        "/MK << /BC [0.45 0.45 0.45] /BG [0.85 0.85 0.85] /CA (%s) >> /AP << /N %d 0 R >> >>"
        % (esc(name), FX, y, FX + w, y + h, page, esc(caption), ap))
    fields.append(num)
    annots.append(num)


# ---------------------------------------------------------------------- layout
label(LX, 742, "Sample form with all field types", 16)
label(LX, 723, "Every AcroForm field type GroupDocs.Parser can meet, each carrying a value.", 9)

cursor = [698]


def row(text, height):
    """Reserve a row, draw its label top-aligned, return the field's bottom y."""
    y = cursor[0] - height
    label(LX, y + height - 10, text)
    cursor[0] = y - ROW_GAP
    return y


add_text("FullName", "John Smith", row("Full name (text)", 20))
add_text("Email", "john.smith@example.com", row("E-mail (text)", 20))
add_text("BirthDate", "1985-04-12", row("Birth date (text)", 20))
add_text("Password", "s3cr3t", row("Password (text, masked)", 20),
         shown="******", flags=8192)                                   # bit 14 Password
add_text("AccountNumber", "ACC-000418", row("Account no. (text, read only)", 20),
         flags=1)                                                      # bit 1  ReadOnly
add_text("Comments", "First line of the comment.\nSecond line of the comment.",
         row("Comments (text, multiline)", 52), h=52, flags=4096,      # bit 13 Multiline
         multiline=True)

add_checkbox("Subscribe", row("Subscribe (check box, on)", 13), True)
add_checkbox("AcceptTerms", row("Accept terms (check box, off)", 13), False)

add_radio("Gender", ["Male", "Female", "Other"], "Female", row("Gender (radio buttons)", 13))

add_choice("Country", ["Australia", "Canada", "Germany", "Japan",
                       "United Kingdom", "United States"],
           row("Country (drop-down list)", 20), flags=131072,          # bit 18 Combo
           value="Germany")
add_choice("City", ["Berlin", "Hamburg", "Munich"],
           row("City (editable drop-down)", 20), flags=393216,         # Combo + bit 19 Edit
           value="Berlin")
add_choice("Language", ["English", "French", "German", "Spanish"],
           row("Language (list box)", 34), flags=0, value="German", h=34)
add_choice("Skills", ["C#", "Java", "Python", "SQL"],
           row("Skills (list box, multi-select)", 34), flags=2097152,  # bit 22 MultiSelect
           values=["C#", "SQL"], h=34)

add_signature("Signature", row("Signature (signature)", 38))
add_button("SubmitButton", "Submit", row("Submit (push button)", 22))

# --------------------------------------------------------------- page assembly
ops = ["q", "0.15 0.15 0.15 rg"]
for x, y, size, text in labels:
    ops.append("BT /Helv %d Tf %g %g Td (%s) Tj ET" % (size, x, y, esc(text)))
ops += ["0.6 G 0.7 w", "%d 736 m %d 736 l S" % (LX, W - LX), "Q"]
stream_obj(content, "", "\n".join(ops))

put(page,
    "<< /Type /Page /Parent %d 0 R /MediaBox [0 0 %d %d] /Contents %d 0 R "
    "/Resources << /Font << /Helv %d 0 R /ZaDb %d 0 R >> >> /Annots [%s] >>"
    % (pages, W, H, content, helv, zadb, " ".join("%d 0 R" % a for a in annots)))
put(pages, "<< /Type /Pages /Kids [%d 0 R] /Count 1 >>" % page)
put(catalog,
    "<< /Type /Catalog /Pages %d 0 R /AcroForm << /Fields [%s] /NeedAppearances true "
    "/DA (/Helv 0 Tf 0 g) /DR << /Font << /Helv %d 0 R /ZaDb %d 0 R >> >> >> >>"
    % (pages, " ".join("%d 0 R" % f for f in fields), helv, zadb))

# ------------------------------------------------------------------ serialise
out = bytearray(b"%PDF-1.7\n%\xe2\xe3\xcf\xd3\n")
offsets = {}
for num in sorted(objects):
    offsets[num] = len(out)
    out += ("%d 0 obj\n" % num).encode("latin-1") + objects[num] + b"\nendobj\n"

xref_at = len(out)
count = max(objects) + 1
out += ("xref\n0 %d\n" % count).encode("latin-1") + b"0000000000 65535 f \n"
for num in range(1, count):
    out += ("%010d 00000 n \n" % offsets[num]).encode("latin-1")
out += ("trailer\n<< /Size %d /Root %d 0 R >>\nstartxref\n%d\n%%%%EOF\n"
        % (count, catalog, xref_at)).encode("latin-1")

with open(sys.argv[1], "wb") as fh:
    fh.write(out)

print("wrote %s (%d bytes, %d objects, %d top-level fields, %d widgets)"
      % (sys.argv[1], len(out), len(objects), len(fields), len(annots)))
