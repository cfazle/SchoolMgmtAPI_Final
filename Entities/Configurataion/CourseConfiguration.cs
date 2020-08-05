using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Entities.Configuration
{
    public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.HasData
            (
                new Course
                {
                    Id = new Guid("80abbca8-664d-4b20-b5de-024705497d4b"),
                    CourseName = "Acc101",
                    CreatedDate = Convert.ToDateTime("11/16/2019"),
                    UpdatedDate = Convert.ToDateTime("06/24/2019"),
                    OrganizationId = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870")
                },
                new Course
                {
                    Id = new Guid("86dba8c0-d178-41e7-938c-ed49778fb52c"),
                    CourseName = "Math108",
                    CreatedDate = Convert.ToDateTime("11/16/2019"),
                    UpdatedDate = Convert.ToDateTime("06/24/2019"),
                    OrganizationId = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870")
                },
                 new Course
                 {
                     Id = new Guid("021ca3c1-0deb-4afd-ae94-2159a8479822"),
                     CourseName = "IS690",
                     CreatedDate = Convert.ToDateTime("11/16/2019"),
                     UpdatedDate = Convert.ToDateTime("06/24/2019"),
                     OrganizationId = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870")
                 }
            );
        }
    }
}
