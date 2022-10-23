﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.AdvertisementApp.Dtos.AdvertisementAppUserStatusDtos;
using Udemy.AdvertisementApp.Dtos.Interfaces;
using Udemy.AdvertisementApp.Dtos.MilitaryStatusDtos;

namespace Udemy.AdvertisementApp.Dtos
{
    public class AdvertisementAppUserListDto:IDto
    {
        public int Id { get; set; }
        public int AdvertisementId { get; set; }
        public AdvertisementListDto Advertisement { get; set; }

        public int AppUserId { get; set; }

        public AppUserListDto AppUser { get; set; }

        public int AdvertisementAppUserStatusId { get; set; }

        public AdvertisementAppUserStatusListDto AdvertisementAppUserStatus { get; set; }

        public int MilitaryStatusId { get; set; }

        public MilitaryStatusListDto MilitaryStatus { get; set; }

        public DateTime? EndDate { get; set; }

        public int WorkExperience { get; set; }

        public string CvPath { get; set; }
    }
}
