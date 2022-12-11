namespace Matching.Controllers
{
    public class Files:IFile
    {
        const string PATH = @"C:\Users\user\Documents\APIProj\MatchingProj\DocumentationFile.txt";
        //const string PATH = @"C:\Users\משתמש זה\Desktop\APIProj\MatchingProj\Matching\DocumentationFile.txt";

        public void Dofile(string url)
        {
            try
            {
                if (File.Exists(PATH))
                {
                    File.AppendAllText(PATH, $"The request has reached the server {url} at {DateTime.Now.ToLocalTime()}\n");
                }
                else
                {
                    File.CreateText(PATH);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Executing finally block.");
            }
        }



        //public static void WriteToFile(string url)
        //{
        //    try
        //    {
        //        string path = @"C:\Users\user\Desktop\פרוייקט\פרוייקט API\MatchingProj\Matching\DocumentationFile.txt";
        //        StreamWriter sw = new StreamWriter(path);
        //        // StreamWriter sw = File.AppendText(path);

        //        //Write a line of text
        //        sw.WriteLine($"The request has reached the server at {DateTime.Now.ToLocalTime()}");
        //        //var baseUrl = Request.RequestUri.GetLeftPart(UriPartial.Authority);
        //        //var url = Url.Content("~/");
        //        //var requestUrl = $"{Request.Scheme}://{Request.Host.Value}/";
        //        //Close the file
        //        sw.WriteLine(url);
        //        sw.Close();
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine("Exception: " + e.Message);
        //    }
        //    finally
        //    {
        //        Console.WriteLine("Executing finally block.");
        //    }
        //}
    }
}
