using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilExplorer.DataLayer.Models
{
    [Table("Folder")]
    public class FolderModel
    {
        [Key]
        public string FolderID { get; set; }

        [Display(Name = "Folder Name")]
        public string Name { get; set; }

        [Display(Name = "Creation Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        [DataType(DataType.DateTime)]
        public DateTime CreationDate { get; set; }

        [Display(Name = "Parent Folder")]
        public String ParentFolder { get; set; }


        //To store the full address path of a folder
        [Display(Name = "Full Path")]
        public String FullPath { get; set; }

        //To store the type of the folder , mainly to identify System folders that should not be deleted
        [Display(Name = "Type")]
        public String Type { get; set; }

        // Link to the relationship with FileModel
        public List<FileModel> Files { get; set; }

        // Link to the relationship with Identity Model
        //public virtual string UserID { get; set; }

        //Foreign key for the Identity Model
        public string UserId { get; set; }

        //TODO need to IoC the identity model
        //public virtual IdentityUser User { get; set; }


    }
}
