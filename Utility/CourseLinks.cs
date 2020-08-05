using Contracts;
using Entities.DataTransferObjects;
using Entities.LinkModels;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SchoolMgmtAPI.Utility
{
    public class CourseLinks
    {
        private readonly LinkGenerator _linkGenerator;
        private readonly IDataShaper<CourseDto> _dataShaper;

        public CourseLinks(LinkGenerator linkGenerator, IDataShaper<CourseDto> dataShaper)
        {
            _linkGenerator = linkGenerator;
            _dataShaper = dataShaper;
        }

        public LinkResponse TryGenerateLinks(IEnumerable<CourseDto> coursesDto, string fields,
            Guid orgId, HttpContext httpContext)
        {
            var shapedCourses = ShapeData(coursesDto, fields);

            if (ShouldGenerateLinks(httpContext))
                return ReturnLinkdedCourses(coursesDto, fields, orgId, httpContext, shapedCourses);

            return ReturnShapedCourses(shapedCourses);
        }

        private List<Entity> ShapeData(IEnumerable<CourseDto> coursesDto, string fields) =>
            _dataShaper.ShapeData(coursesDto, fields)
                .Select(e => e.Entity)
                .ToList();

        private bool ShouldGenerateLinks(HttpContext httpContext)
        {
            var mediaType = (MediaTypeHeaderValue)httpContext.Items["AcceptHeaderMediaType"];

            return mediaType.SubTypeWithoutSuffix.EndsWith("hateoas", 
                StringComparison.InvariantCultureIgnoreCase);
        }

        private LinkResponse ReturnShapedCourses(List<Entity> shapedCourses) => 
            new LinkResponse { ShapedEntities = shapedCourses };

        private LinkResponse ReturnLinkdedCourses(IEnumerable<CourseDto> coursesDto, 
            string fields, Guid orgId, HttpContext httpContext, List<Entity> shapedCourses)
        {
            var courseDtoList = coursesDto.ToList();

            for (var index = 0; index < courseDtoList.Count(); index++)
            {
                var courseLinks = CreateLinksForCourse(httpContext, orgId, courseDtoList[index].Id, fields);
                shapedCourses[index].Add("Links", courseLinks);
            }

            var courseCollection = new LinkCollectionWrapper<Entity>(shapedCourses);
            var linkedcourses = CreateLinksForCourses(httpContext, courseCollection);

            return new LinkResponse { HasLinks = true, LinkedEntities = linkedcourses };
        }

        private List<Link> CreateLinksForCourse(HttpContext httpContext,
            Guid orgId, Guid id, string fields = "")
        {
            var links = new List<Link>
            {
                new Link(_linkGenerator.GetUriByAction(httpContext, "GetCourseForOrganization", 
                values: new { orgId, id, fields }),
                "self",
                "GET"),
                new Link(_linkGenerator.GetUriByAction(httpContext, "DeleteCourseForOrganization",
                values: new {orgId, id }),
                "delete_course",
                "DELETE"),
                new Link(_linkGenerator.GetUriByAction(httpContext, "UpdateCourseForOrganization",
                values: new { orgId, id }),
                "update_course",
                "PUT"),
                new Link(_linkGenerator.GetUriByAction(httpContext, "PartiallyUpdateCourseForOrganization",
                values: new { orgId, id }),
                "partially_update_course",
                "PATCH")
            };

            return links;
        }

        private LinkCollectionWrapper<Entity> CreateLinksForCourses(HttpContext httpContext,
            LinkCollectionWrapper<Entity> coursesWrapper)
        {
          coursesWrapper.Links.Add(new Link(_linkGenerator.GetUriByAction(httpContext, 
              "GetCoursesForOrganization", values: new { }),
                    "self",
                    "GET"));

            return coursesWrapper;
        }
    }
}