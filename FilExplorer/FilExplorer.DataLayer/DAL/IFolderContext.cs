using FilExplorer.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilExplorer.DataLayer.DAL
{
    interface IFolderContext
    {
        System.Data.Entity.IDbSet<FolderModel> Folders { get; set; }
        void Commit();
        void DisposeOfObject();
        //For testing purposes
        IQueryable<FolderModel> GetAllFolders { get; }
    }
}
