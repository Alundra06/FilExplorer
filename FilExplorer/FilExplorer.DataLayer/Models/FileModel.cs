using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilExplorer.DataLayer.Models
{
    [Table("File")]
    public class FileModel
    {
        [Key]
        public string FileID { get; set; }

        [Display(Name = "File Name")]
        public string Name { get; set; }

        [Display(Name = "Upload Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        [DataType(DataType.DateTime)]
        public DateTime UploadDate { get; set; }

        [Display(Name = "File Path")]
        public String FilePath { get; set; }

        [Display(Name = "Folder Path")]
        public String FolderPath { get; set; }


        //Foreign key for the folder model
        //Every file should belong to a folder
        public string FolderID { get; set; }
        public virtual FolderModel Folder { get; set; }

    }
}
