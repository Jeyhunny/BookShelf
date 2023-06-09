﻿using AutoMapper;
using Domain.Entities;
using Service.Services.DTOs.AppUser;
using Service.Services.DTOs.Banner;
using Service.Services.DTOs.Blog;
using Service.Services.DTOs.BlogImage;
using Service.Services.DTOs.Comment;
using Service.Services.DTOs.Contact;
using Service.Services.DTOs.Movflix;
using Service.Services.DTOs.Movie;
using Service.Services.DTOs.MovieCategory;
using Service.Services.DTOs.MovieComment;
using Service.Services.DTOs.Pricing;
using Service.Services.DTOs.Service;

namespace Service.Services.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<BookShelfCreateDto, BookShelf>().ReverseMap();
            CreateMap<BookShelfUpdateDto, BookShelf>().ReverseMap();
            CreateMap<BookShelfListDto, BookShelf>().ReverseMap();

            CreateMap<BlogCreateDto, Blog>().ReverseMap();
            CreateMap<BlogUpdateDto, Blog>().ReverseMap();
            CreateMap<BlogListDto, Blog>().ReverseMap();
            CreateMap<BlogGetDto, Blog>().ReverseMap();

            CreateMap<CommentCreateDto, Comment>().ReverseMap();
            CreateMap<CommentListDto, Comment>().ReverseMap();

            CreateMap<BookCommentCreateDto, BookComment>().ReverseMap();
            CreateMap<BookCommentListDto, BookComment>().ReverseMap();

            CreateMap<ContactListDto, Contact>().ReverseMap();
            CreateMap<ContactUpdateDto, Contact>().ReverseMap();
            CreateMap<ContactGetDto, Contact>().ReverseMap();
       

            CreateMap<BannerCreateDto, Banner>().ReverseMap();
            CreateMap<BannerUpdateDto, Banner>().ReverseMap();
            CreateMap<BannerListDto, Banner>().ReverseMap();
            CreateMap<BannerGetDto, Banner>().ReverseMap();

            CreateMap<ServiceCreateDto,Servise >().ReverseMap();
            CreateMap<ServiceUpdateDto, Servise>().ReverseMap();
            CreateMap<ServiceListDto, Servise>().ReverseMap();
            CreateMap<ServiceGetDto, Servise>().ReverseMap();


            CreateMap<PricingCreateDto, Pricing>().ReverseMap();
            CreateMap<PricingUpdateDto, Pricing>().ReverseMap();
            CreateMap<PricingGetDto, Pricing>().ReverseMap();
            CreateMap<PricingListDto, Pricing>().ReverseMap();

            CreateMap<BookCreateDto, Movie>().ReverseMap();
            CreateMap<BookUpdateDto, Movie>().ReverseMap();
            CreateMap<BookListDto, Movie>().ReverseMap();
            CreateMap<BookGetDto, Movie>().ReverseMap();


            CreateMap<BookCategoryCreateDto, BookCategory>().ReverseMap();
            CreateMap<BookCategoryUpdateDto, BookCategory>().ReverseMap();            
            CreateMap<BookCategoryListDto, BookCategory>().ReverseMap();
            

            CreateMap<BlogImageListDto, BlogImage>().ReverseMap();

            CreateMap<AppUser, RegisterDto>().ReverseMap();
            CreateMap<UserDto, AppUser>().ReverseMap();
            CreateMap<AppUser, UpdatePasswordDto>().ReverseMap();
            CreateMap<AppUser, UpdateUserDto>().ReverseMap();

        }
    }
}
