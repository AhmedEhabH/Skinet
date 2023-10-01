using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using AutoMapper;
using Core.Entities;

namespace API.Helpers
{
    public class ProductUrlResolver : IValueResolver<Product, ProductToReturnDto, string> // src, destination(map to), destination member
    {
        private readonly IConfiguration _congfig;
        public ProductUrlResolver(IConfiguration congfig)
        {
            _congfig = congfig;

        }

        public string Resolve(Product source, ProductToReturnDto destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.PictureUrl))
            {
                return _congfig["ApiUrl"] + source.PictureUrl;
            }

            return null;
        }
    }
}