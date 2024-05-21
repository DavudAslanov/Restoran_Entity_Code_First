﻿using Entities.Concrete.TableModels;

namespace Entities.Concrete.Dtos
{
    public class TestmonialUpdateDto
    {
        public int ID { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FeedBack { get; set; }

        public string PhotoUrl { get; set; }

        public static Testmonial ToTestmonial(TestmonialUpdateDto dto)
        {
            Testmonial Testmonial = new()
            {
                ID = dto.ID,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                FeedBack = dto.FeedBack,
                PhotoUrl = dto.PhotoUrl,
            };
            return Testmonial;
        }
    }
}