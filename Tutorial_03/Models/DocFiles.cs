namespace Tutorial_03.Models
{
    public class DocFiles
    {
        //This method gets all filenames from folder...
        // ... instead of get them form a database or other storage kind

        public List<FileViewModel> GetFiles(IHostEnvironment e)
        {
            List<FileViewModel> list = new List<FileViewModel>();//cria lista vazia

            // Get all information from "wwwroot/Documents" folder
            DirectoryInfo dirInfo = new DirectoryInfo(
                Path.Combine(e.ContentRootPath, "wwwroot/Documents")
                );

            // use the information from folder to get the filenames
            foreach (var item in dirInfo.GetFiles())
            {
                list.Add(
                    new FileViewModel
                    {
                        Name = item.Name,
                        Size = item.Length
                    });
            }
            return list;
        }
    }
}
