using System;
using GroupDocs.Parser.Live.Demos.UI.Config;
using System.Web;
using GroupDocs.Parser.Live.Demos.UI.Models;
using System.Text.RegularExpressions;
using GroupDocs.Parser.Live.Demos.UI.Helpers;

namespace GroupDocs.Parser.Live.Demos.UI
{
	public partial class Default : BasePage
	{
		public string fileFormat = "";
		public string features = "";
		string logMsg = "";

		private string GetValidFileExtensions(string validationExpression)
		{
			string validFileExtensions = validationExpression.Replace(".", "").Replace("|", ", ").ToUpper();

			int index = validFileExtensions.LastIndexOf(",");
			if (index != -1)
			{
				string substr = validFileExtensions.Substring(index);
				string str = substr.Replace(",", " or");
				validFileExtensions = validFileExtensions.Replace(substr, str);
			}

			return validFileExtensions;
		}

		public string GetFormatProducer(string formatName)
		{
			switch (formatName.ToLower())
			{
				case "xls":
				case "xlsx":
				case "xlsm":
				case "xlsb":
				case "xlt":
				case "xltm":
				case "xltx":
					return "Microsoft Excel";
				case "ods":
					return "OpenDocument";
				case "doc":
				case "docx":
				case "docm":
				case "dot":
				case "dotm":
				case "dotx":
					return "Microsoft Word";
				case "rtf":
					return "Rich Text Format";
				case "odt":
					return "OpenDocument";
				case "csv":
					return "Comma-Separated Values (CSV)";
				case "tsv":
					return "Tab-Separated Values (TSV)";
				case "ppt":
				case "pptx":
				case "pptm":
				case "pps":
				case "ppsx":
				case "ppsm":
					return "Microsoft PowerPoint";
				case "odp":
					return "OpenDocument";
				case "one":
					return "Microsoft OneNote";
				case "eml":
					return "E-Mail Message";
				case "md":
					return "Markdown";
				default:
					return formatName;
			}
		}

		public bool IsExtractImageSupported(string formatName)
		{
			switch (formatName.ToLower())
			{
				case "csv":
				case "tsv":
				case "md":
				case "xml":
					return false;
				default:
					return true;
			}
		}

		protected void Page_Load(object sender, EventArgs e)
		{
			this.features = "extract text, metadata and images ";
			if (!IsPostBack)
			{
				dvAllFormats.Visible = true;

				aPoweredBy.InnerText = "GroupDocs.Parser. "; ;
				aPoweredBy.HRef = "https://products.groupdocs.com/parser";

				BuildValidator();

				string commonTitleFormatsSet = "DOC, DOCX, PDF, XLSX, PPTX, EML";
				string commonMetaFormatsSet = "ODS, XLS, XLSX, XLSM, XLSB, CSV, XLS2003, XLTX, XLTM, TIFF, TIF, JPEG, JPG, PNG, GIF, BMP, ICO, PSD, SVG, WEBP, JP2, PDF, EPUB, XPS, PPT, PPS, PPTX, PPSX, ODP, OTP, POTX, POTM, PPTM, PPSM, DOC, DOCM, DOCX, DOT, DOTM, DOTX, RTF, TXT, ODT, OTT, HTML and other";

				if (Page.RouteData.Values["fileformat"] == null)
				{
					Page.Title = BuildTitle(commonTitleFormatsSet);
					Page.MetaDescription = BuildMeta(commonMetaFormatsSet);

					hheading.InnerHtml = BuildHeading(commonTitleFormatsSet);
					hdescription.InnerHtml = BuildSubHeading("Word, Excel, PDF, emails and other types of ");
				}
				else
				{
					string fileFormat = Page.RouteData.Values["fileformat"].ToString();

					hheading.InnerHtml = BuildHeading(fileFormat.ToUpper());
					hdescription.InnerHtml = BuildSubHeading(fileFormat.ToUpper());
					hfToFormat.Value = fileFormat;

					Page.Title = BuildTitle(fileFormat.ToUpper());
					Page.MetaDescription = BuildMeta(fileFormat.ToUpper());
				}
			}
		}

		private void BuildValidator()
		{
			string validationExpression = Resources["ParserValidationExpression"];
			if (Page.RouteData.Values["fileformat"] != null)
			{
				validationExpression = "." + Page.RouteData.Values["fileformat"].ToString().ToLower();
			}

			string validFileExtensions = GetValidFileExtensions(validationExpression);
			ValidateFileType.ValidationExpression = @"(.*?)(" + validationExpression.ToLower() + "|" + validationExpression.ToUpper() + ")$";
			ValidateFileType.ErrorMessage = Resources["InvalidFileExtension"] + " " + validFileExtensions;
		}

		private bool AccentToExtract(string formats)
		{
			switch(formats.ToUpper())
			{
				case "PDF":
					return true;
				default:
					return false;
			}
		}

#region BuildTitle
		private string BuildTitle(string formats)
		{
			if (AccentToExtract(formats))
				return BuildTitle_Extract(formats);
			return BuildTitle_Parse(formats);
		}
		private string BuildTitle_Parse(string formats)
		{
			string prefix = "Parse ";
			string suffixNoImages = " to Extract Text Online Free";
			string suffix = " to Extract Text and Images Online Free - GroupDocs.App";

			return prefix + formats + (IsExtractImageSupported(formats) ? suffix : suffixNoImages);
		}
		private string BuildTitle_Extract(string formats)
		{			
			string prefixNoImages = "Extract Text from ";
			string prefix = "Extract Text and Images from ";
			string suffix = " Free Online - GroupDocs.App";

			return (IsExtractImageSupported(formats) ? prefix : prefixNoImages) + formats + suffix;
		}
#endregion

		private string BuildMeta(string formats)
		{
			string prefix = "Parse ";
			string medium = " documents online and ";
			string features = "extract text, metadata and images ";
			string featuresNoImage = "extract text and metadata ";
			string suffix = "for free";

			return prefix + formats + medium + (IsExtractImageSupported(formats) ? features : featuresNoImage) + suffix;
		}
		#region BuildHeading
		private string BuildHeading(string formats)
		{
			if (AccentToExtract(formats))
				return BuildHeading_Extract(formats);
			return BuildHeading_Parse(formats);
		}
		private string BuildHeading_Parse(string formats)
		{
			string prefix = "Parse ";
			string suffixNoImages = " to Extract Text Online Free";
			string suffix = " to Extract Text and Images Online Free";

			return prefix + formats + (IsExtractImageSupported(formats) ? suffix : suffixNoImages);
		}
		private string BuildHeading_Extract(string formats)
		{			
			string prefixNoImages = "Extract Text from ";
			string prefix = "Extract Text and Images from ";
			string suffix = " Free Online";

			return (IsExtractImageSupported(formats) ? prefix : prefixNoImages) + formats + suffix;
		}
#endregion

		private string BuildSubHeading(string formats)
		{
			string prefix = "Extract data quickly and easily from ";
			string medium = " documents with this online Parser.";

			return prefix + GetFormatProducer(formats) + medium;
		}

		private void ProcessClick(string parseType)
		{
            Configuration.GroupDocsAppsAPIBasePath = Request.Url.Scheme + "://" + Request.Url.Authority + Request.ApplicationPath.TrimEnd('/') + "/";
            Configuration.FileDownloadLink = Configuration.GroupDocsAppsAPIBasePath + "DownloadFile.aspx";

            if (IsValid)
			{
				if ((UploadFile.PostedFile != null) && (UploadFile.PostedFile.ContentLength > 0))
				{
					string fn = Regex.Replace(System.IO.Path.GetFileName(UploadFile.PostedFile.FileName).Trim(), @"\A(?!(?:COM[0-9]|CON|LPT[0-9]|NUL|PRN|AUX|com[0-9]|con|lpt[0-9]|nul|prn|aux)|[\s\.])[^\\\/:*"" ?<>|]{ 1,254}\z", "");
					string SaveLocation = Configuration.AssetPath + fn;

					try
					{
						UploadFile.PostedFile.SaveAs(SaveLocation);

						var isFileUploaded = FileManager.UploadFile(SaveLocation, "");
						if ((isFileUploaded != null) && (isFileUploaded.FileName.Trim() != ""))
						{							
							Response response = GroupDocsParserApiHelper.ParseFile(isFileUploaded.FileName, isFileUploaded.FolderId, parseType);							

							if (response == null)
							{
								throw new Exception(Resources["APIResponseTime"]);
							}
							else if (response.StatusCode == 200)
							{
								string url = Configuration.FileDownloadLink + "?FileName=" + response.FileName + "&Time=" + DateTime.Now.ToString();
								litDownloadNow.Text = "<a target=\"_blank\" href=\"" + url + "\" class=\"btn btn-success btn-lg\">" + Resources["DownLoadNow"] + " <i class=\"fa fa-download\"></i></a>";
								downloadUrl.Value = HttpUtility.UrlEncode(url);

								ConvertPlaceHolder.Visible = false;
								DownloadPlaceHolder.Visible = true;

								logMsg = "ControllerName: GroupDocsParserController FileName: " + response.FileName + " FolderName: " + isFileUploaded.FolderId + " OutFileExtension: " + "txt";
							}
							else
							{
								string msg = response.Status;

								if (msg.ToLower().Contains("password"))
								{
									string asposeProduct = GetAsposeUnlockProduct(isFileUploaded.FileName);
									if (asposeProduct != null)
									{
										string asposeUrl = Configuration.ProductsGroupDocsAppsURL.ToLower().Replace("groupdocs", "aspose") + "/" + asposeProduct.ToLower() + "/unlock";
										msg = "Your file seems to be encrypted. Please use our <a href=\"" + asposeUrl + "\">\"Unlock " + asposeProduct + "\"</a> app to remove the password.";
									}
								}

								throw new Exception(msg);
							}

						}
					}
					catch (Exception ex)
					{
						pMessage.InnerHtml = "Error: " + ex.Message;
						pMessage.Attributes.Add("class", "alert alert-danger");
					}
				}
				else
				{
					pMessage.InnerHtml = Resources["FileSelectMessage"];
					pMessage.Attributes.Add("class", "alert alert-danger");
				}
			}
		}

		protected void btnParse_Click(object sender, EventArgs e)
		{
			ProcessClick("text");
		}

		protected void btnImages_Click(object sender, EventArgs e)
		{
			ProcessClick("image");
		}

		protected void btnSend_Click(object sender, EventArgs e)
		{
			try
			{
				if (emailTo.Value.Trim() == "")
				{
					pMessage2.InnerHtml = Resources["MissingEmailMsg"];
					pMessage2.Attributes.Add("class", "alert alert-danger");
				}
				else
				{
					string url = HttpUtility.UrlDecode(downloadUrl.Value);
					string emailBody = EmailManager.PopulateEmailBody(Resources["ParserEmailHeading"], url, Resources["FileParsedSuccessMessage1"]);
					EmailManager.SendEmail(emailTo.Value, Configuration.FromEmailAddress, Resources["ParserEmailTitle"], emailBody, "");

					pMessage2.Attributes.Add("class", "alert alert-success");
					pMessage2.InnerHtml = Resources["FileParsedSuccessMessage"];
				}
			}
			catch (Exception ex)
			{
				pMessage2.InnerHtml = "Error: " + ex.Message;
				pMessage2.Attributes.Add("class", "alert alert-danger");
			}
		}

	}
}