using MessagePack;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace MvcRepositoryPatternDemo.Models
{
    public class Book
    {
        public long bookId { get; set; }
        public string Title { get; set; }
        public string Auther { get; set; }
        public decimal Price { get; set; }
        //public byte[] BookImage { get; set; }
    }
}
