using GroupDocs.Parser.Live.Demos.UI.Models;
using GroupDocs.Parser.Live.Demos.UI.Config;
using System.Net.Http;
using System.Net.Http.Headers;

namespace GroupDocs.Parser.Live.Demos.UI.Helpers
{
	public class GroupDocsParserApiHelper
	{
		public static Response ParseFile(string fileName, string folderName, string parseType)
		{
			Response convertResponse = null;

			using (var client = new HttpClient())
			{
				client.DefaultRequestHeaders.Clear();
				client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
				System.Threading.Tasks.Task taskUpload = client.GetAsync(Configuration.GroupDocsAppsAPIBasePath + "api/GroupDocsParser/ParseFile?fileName=" + fileName + "&folderName=" + folderName + "&parseType=" + parseType).ContinueWith(task =>
				{
					if (task.Status == System.Threading.Tasks.TaskStatus.RanToCompletion)
					{
						HttpResponseMessage response = task.Result;
						if (response.IsSuccessStatusCode)
						{
							convertResponse = response.Content.ReadAsAsync<Response>().Result;
						}
					}
				});
				taskUpload.Wait();
			}

			return convertResponse;
		}
		
	}
}