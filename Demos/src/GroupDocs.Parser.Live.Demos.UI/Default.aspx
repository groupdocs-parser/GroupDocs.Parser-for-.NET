<%@ Page Title="Parse DOC, DOCX, PDF, XLSX, PPTX, EML to Extract Text and Images Online Free" MetaDescription="Parse ODS, XLS, XLSX, XLSM, XLSB, CSV, XLS2003, XLTX, XLTM, TIFF, TIF, JPEG, JPG, PNG, GIF, BMP, ICO, PSD, SVG, WEBP, JP2, PDF, EPUB, XPS, PPT, PPS, PPTX, PPSX, ODP, OTP, POTX, POTM, PPTM, PPSM, DOC, DOCM, DOCX, DOT, DOTM, DOTX, RTF, TXT, ODT, OTT, HTML and other documents online and extract text, metadata and images for free" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="GroupDocs.Parser.Live.Demos.UI.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
	<asp:UpdatePanel ID="UpdatePanel1" runat="server">
		<ContentTemplate>      
			<div class="container-fluid GroupDocsApps">
				<div class="container">
					<div class="row">
						<div class="col-md-12 pt-5 pb-5">
							<h1 id="hheading" runat="server">Extract Text, Metadata and Images With Free Online Document Parser</h1>
							<h2 style="font-size: 22px !important; color: #fff !important;" id="hdescription" runat="server">Extract text and metadata from Word, Excel, PDF, emails and other types of documents</h2>                        						                                
							<div class="form">
								<asp:PlaceHolder ID="ConvertPlaceHolder" runat="server">
									<div class="uploadfile">
										<div class="filedropdown">
											<div class="filedrop">
												<label class="dz-message needsclick"><%=Resources["DropOrUploadFile"]%></label>
												<input type="file" name="UploadFile" id="UploadFile" runat="server" class="uploadfileinput" />
												<asp:RegularExpressionValidator ID="ValidateFileType" ValidationExpression="([a-zA-Z0-9\s)\s(\s_\\.\-:])+(.doc|.docx|.dot|.dotx|.rtf)$"
													ControlToValidate="UploadFile" runat="server" ForeColor="Red"
													Display="Dynamic" />
												<asp:HiddenField ID="hdnFileExtensionMessage" runat="server" />
												<div class="fileupload">
													<span class="filename">
														<a href="#">
															<label for="uploadfileinput" id="lblFilename" class="custom-file-upload"></label>
														</a>
													</span>
												</div>
											</div>
											<p runat="server" id="pMessage"></p>
                                            <asp:HiddenField ID="hfToFormat" Value="~" runat="server" />
											<div class="convertbtn">
												<asp:Button runat="server" ID="btnParse" class="btn btn-success btn-lg" Text="Get Text and Metadata" OnClick="btnParse_Click" />
											</div>                                            
                                            <div class="convertbtn">
												<asp:Button runat="server" ID="btnImages" class="btn btn-success btn-lg" Text="Get Images" OnClick="btnImages_Click" />
											</div>
											<asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
												<ProgressTemplate>
													<div>
														<img height="59px" width="59px" alt="Please wait..." src="../../img/loader.gif" />
													</div>
												</ProgressTemplate>
											</asp:UpdateProgress>
										</div>
									</div>
								</asp:PlaceHolder>

								<asp:PlaceHolder ID="DownloadPlaceHolder" runat="server" Visible="false">
									<div class="filesendemail">

										<div class="filesuccess">
											<label class="dz-message needsclick"><%=Resources["FileParsedSuccessMessage1"]%></label>
											<span class="downloadbtn convertbtn">
												<asp:Literal ID="litDownloadNow" runat="server"></asp:Literal>
											</span>
											<div class="clearfix">&nbsp;</div>
											<a href="/" class="btn btn-link refresh-c"><%=Resources["ParseAnotherFile"]%> <i class="fa-refresh fa "></i></a>
                                            <a class="btn btn-link" target="_blank" href="https://products.groupdocs.cloud/parser/family">Parse more data with <strong>Cloud API</strong> &nbsp;<i class="fa-cloud fa"></i></a>
										</div>

										<p><%=Resources["SendTo"]%> </p>
										<div class="col-5 sendemail">
											<div class="input-group input-group-lg">
												<input type="email" id="emailTo" name="emailTo" class="form-control" placeholder="email@domain.com" runat="server" />
												<input type="hidden" id="downloadUrl" name="downloadUrl" runat="server" />
												<span class="input-group-btn">
													<asp:LinkButton class="btn btn-success" type="button" ID="btnSend" runat="server" OnClick="btnSend_Click" Text="<i class='fa fa-envelope-o fa'></i>" />
												</span>
											</div>
										</div>
										<br />
										<asp:UpdateProgress ID="UpdateProgress2" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
											<ProgressTemplate>
												<div>
													<img height="59px" width="59px" alt="Please wait..." src="../../img/loader.gif" />
												</div>
											</ProgressTemplate>
										</asp:UpdateProgress>
										<p runat="server" id="pMessage2"></p>
									</div>
								</asp:PlaceHolder>


							</div>

						</div>
					</div>
				</div>
			</div>
			<div class="col-md-12 pt-5 bg-gray tc" id="dvAllFormats" runat="server">
				<div class="container">
					<div class="col-md-12 pull-left">
						<h2 class="h2title">GroupDocs.Parser App</h2>
						<p>GroupDocs.Parser App Supported Document Formats</p>
						<div class="diagram1 d2 d1-net">
							<div class="d1-row">
								<div class="d1-col d1-left">
									<header>Text Extraction</header>
									<ul>
										<li><strong>Text:</strong> DOC, DOCX, DOT, DOCM, RTF, ODT, TXT, MD, WordprocessingML (XML)‎</li>
										<li><strong>Spreadsheets:</strong> XLS, XLSX, CSV, XLSM, XLSB, ODS, SpreadsheetML (XML), TSV</li>
										<li><strong>Presentations:</strong> PPT, PPTX, PPTM, PPS, PPSX, PPSM, ODP</li>
										<li><strong>OneNote:</strong> ONE</li>
										<li><strong>Email:</strong> MSG, EML, EMLX, PST, OST, MS EXCHANGE SERVER, POP, IMAP</li>
										<li><strong>Electronic Publishing:</strong> EPUB, FB2</li>
                                        <li><strong>Portable Document:</strong> PDF, PDF Portfolio, Encrypted PDF</li>
										<li><strong>DOM-Based:</strong> XML, HTML, XHTML, MHTML</li>
										<li><strong>Compression & Packaging:</strong> CHM</li>
										<li><strong>Database:</strong> ADO.NET</li>
									</ul>
									<header>Image Extraction</header>
									<ul>
										<li><strong>Text:</strong> DOC, DOCX, DOCM, RTF, DOT, DOTM, DOTX, ODT‎</li>
										<li><strong>Spreadsheets:</strong> XLS, XLSX, XLSM, XLSB, ODS, XLT, XLTM, XLTX</li>
										<li><strong>Presentations:</strong> PPT, PPTX, PPTM, ODP, PPS, PPSX, PPSM</li>
                                        <li><strong>Portable Document:</strong> PDF, POT, POTM, POTX</li>
									</ul>
								</div>
								<!--/left-->
                               
								<div class="d1-col d1-right">
									<header>Metadata Extraction</header>
									<ul>
										<li><strong>Text:</strong> DOC, DOCX, DOT, ODT</li>
										<li><strong>Spreadsheets:</strong> XLS, XLSX, ODS</li>
										<li><strong>Presentations:</strong> PPT, PPTX, ODP</li>
										<li><strong>Email:</strong> MSG, EML, EMLX</li>
										<li><strong>Electronic Publishing:</strong> EPUB, FB2‎</li>
										<li><strong>Other:</strong> PDF</li>
									</ul>
									<header>Text & Metadata Extraction</header>
									<ul>
										<li><strong>Template:</strong> DOTX, POTX</li>
										<li><strong>Macro-Enabled Template:</strong> DOTM, POTM</li>
										<li><strong>OpenDocument Template:</strong> OTT</li>
									</ul>
									<header>Encoding Detection</header>
									<ul>
										<li><strong>BOM:</strong> UTF32 LE, UTF32 BE, UTF16 LE, UTF16 BE, UTF8, and UTF7</li>
										<li><strong>Content:</strong> UTF32 LE, UTF32 BE, UTF16 LE, UTF16 BE, UTF8, and ANSI</li>										
									</ul>
								</div>                                 
								<!--/right-->
							</div>
							<!--/row-->
							<div class="d1-logo">
								<img src="https://www.groupdocs.cloud/templates/groupdocs/images/product-logos/90x90-noborder/groupdocs-parser-net.png" alt=".NET Files Parser API"><header>GroupDocs.Parser</header>
								<footer><small>App</small></footer>
							</div>
							<!--/logo-->
						</div>
					</div>
				</div>
			</div>

<div class="col-md-12 pull-left d-flex d-wrap bg-gray appfeaturesectionlist" id="dvFormatSection" runat="server" visible="false">
		<div class="col-md-6 cardbox tc col-md-offset-3 b6">
			<h3 runat="server" id="hExtension1"></h3>
			<p runat="server" id="hExtension1Description"></p>
		</div>
</div>

<div class="col-md-12 tl bg-darkgray howtolist">
    <div class="container tl dflex">
        <div class="col-md-4 howtosectiongfx">	        
            <img src="../css/howto.png" />
        </div>
        <div class="howtosection col-md-8">
	        <div>
		        <h4><i class="fa fa-question-circle "></i> <b>How to <%=features %>from a <%=fileFormat  %>document using GroupDocs.Parser App</b></h4>
		        <ul>
                    <li>Click inside the file drop area to upload a <%=fileFormat %>file or drag & drop a <%=fileFormat %>file.
				    <li>Click <b>Get Text and Metadata</b> button.</li>
                    <li>Click <b>Get Images</b> button to extract images from your <%=fileFormat  %>document </li>
                    <li>Once your <%=fileFormat  %>document is parsed click on <b>Download Now</b> button.</li>
                    <li>You may also send the download link to any email address by clicking on <b>Email</b> button.</li>
		        </ul>
	        </div>
        </div>
    </div>
</div>

			<div class="col-md-12 pt-5 app-features-section">
				<div class="container tc pt-5">
					<div class="col-md-4">
						<div class="imgcircle fasteasy">
							<img src="../../img/fast-easy.png" />
						</div>
						<h4><%= Resources["ParserFeature1"] %></h4>
						<p><%= Resources["ParserFeature1Description"] %></p>
					</div>

					<div class="col-md-4">
						<div class="imgcircle anywhere">
							<img src="../../img/anywhere.png" />
						</div>
						<h4><%= Resources["ParserFeature2"] %></h4>
						<p><%= Resources["Feature2Description"] %></p>
					</div>

					<div class="col-md-4">
						<div class="imgcircle quality">
							<img src="../../img/quality.png" />
						</div>
						<h4><%= Resources["ParserFeature3"] %></h4>
						<p><%= Resources["PoweredBy"] %> <a runat="server" target="_blank" id="aPoweredBy"></a><%= Resources["QualityDescMetadata"] %></p>
					</div>
				</div>
			</div>

			<script type="text/javascript">
				window.onsubmit = function () {
					if (Page_IsValid) {

						var updateProgress = $find("<%= UpdateProgress1.ClientID %>");
						if (updateProgress) {
							window.setTimeout(function () {
								updateProgress.set_visible(true);
								document.getElementById('<%= pMessage.ClientID %>').style.display = 'none';
							}, 100);
						}

						var updateProgress2 = $find("<%= UpdateProgress2.ClientID %>");
						if (updateProgress2) {
							window.setTimeout(function () {
								updateProgress2.set_visible(true);
								document.getElementById('<%= pMessage2.ClientID %>').style.display = 'none';
							}, 100);
						}
					}
				}
			</script>
			<script>
				$(document).ready(function () {
					bindEvents();
				});

				Sys.WebForms.PageRequestManager.getInstance().add_endRequest(function (evt, args) {
					bindEvents();
				});

				function bindEvents() {
					$('.fileupload').hide();
					$('#<%= UploadFile.ClientID %>').change(function () {
						$('.fileupload').hide();
						var file = document.getElementById('<%= UploadFile.ClientID %>').files[0].name;
						$('#lblFilename').text(file);
						$('.fileupload').show();
						document.getElementById('<%= pMessage.ClientID %>').style.display = 'none';
					});

					if (/Android|webOS|iPhone|iPad|iPod|BlackBerry|IEMobile|Opera Mini/i.test(navigator.userAgent)) {

						var swiper = new Swiper('.swiper-container', {
							slidesPerView: 5,
							spaceBetween: 20,
							// init: false,
							pagination: {
								el: '.swiper-pagination',
								clickable: true,
							},
							navigation: {
								nextEl: '.swiper-button-next',
								prevEl: '.swiper-button-prev',
							},
							breakpoints: {
								868: {
									slidesPerView: 4,
									spaceBetween: 20,
								},
								668: {
									slidesPerView: 2,
									spaceBetween: 0,
								}
							}
						});
					}
				}
			</script>
		</ContentTemplate>
		<Triggers>
			<asp:PostBackTrigger ControlID="btnParse" />
            <asp:PostBackTrigger ControlID="btnImages" />
		</Triggers>
	</asp:UpdatePanel>
</asp:Content>
