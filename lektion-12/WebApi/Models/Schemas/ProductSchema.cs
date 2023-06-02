﻿using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using WebApi.Models.Entities;

namespace WebApi.Models.Schemas
{
    public class ProductSchema : IProductSchema
    {
        [Required]
        public string Name { get; set; } = null!;

        [Required]
        public decimal Price { get; set; }



        public static implicit operator ProductEntity(ProductSchema schema)
        {
            try
            {
                if (schema != null)
                    return new ProductEntity
                    {
                        Name = schema.Name,
                        Price = schema.Price
                    };
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); }
            return null!;

        }
    }
}
