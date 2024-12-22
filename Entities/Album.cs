using System.ComponentModel.DataAnnotations.Schema;
using ArtistAPI_DotNet8.Data;
using ArtistAPI_DotNet8.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
namespace ArtistAPI_DotNet8.Entities
{
    public class Album
    {
        public int AlbumId { get; set; }   
        public string Name { get; set; }

        public string Description { get; set; }

        //nav
        public Artist Artist { get; set; }
    }
}
