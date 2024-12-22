using System.ComponentModel.DataAnnotations.Schema;
using ArtistAPI_DotNet8.Data;
using ArtistAPI_DotNet8.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
namespace ArtistAPI_DotNet8.Entities
{
    public class Artist
    {
        public int ArtistId { get; set; }
        public required string Name { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Place { get; set; } = string.Empty ;

        [ForeignKey("Album")]
        public int? AlbumId { get; set; }

        //nav

        public Album Album { get; set; }

    }
}
