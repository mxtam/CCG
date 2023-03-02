using CCG_DB.Models;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System.IO;

namespace CCG_DB
{
    public static class CustomMethods
    {
        public static async void CreateInfoPage(string path, string name, string rank, string description, string imageUrl ) 
        {
            string content = $@"
@{{
    ViewData[""Title""] = ""{name}"";
}}
<h1>{name}</h1>
<label>Photo:</label><br/>
<img src=""{imageUrl}"" style="" width:10%; height:12%; border-radius:20px"" /><br/>
<label>Name:    </label> 
<label>{name}</label><br /> 
<label>Rank:    </label>
<label>{rank}</label><br />
<label>Description:  </label><br/>
<label>{description}</label><br />";



            using (StreamWriter writer = new StreamWriter(path, false))
            {
                await writer.WriteLineAsync(content);

            }
        }

        public static  void DeleteInfoPage(string path)
        {
            FileInfo fileInf = new FileInfo(path);
            if (fileInf.Exists)
            {
                fileInf.Delete();
            }
        }
    }

}
