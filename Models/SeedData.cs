using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace OutOfOffice.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new OutOfOfficeContext(serviceProvider.GetRequiredService<DbContextOptions<OutOfOfficeContext>>()))
            {
                if (context.Request.Any())
                {
                    return; //DB has data, don't seed
                }

                context.Request.AddRange(
                    new Request
                    {
                        Name = "John Smith",
                        Email = "jsmith@saltandlight.technology",
                        ApproverEmail = "admin@saltandlight.technology",
                        RequestType = "Vacation",
                        LeaveDateTime = DateTime.Now,
                        ReturnDateTime = DateTime.Now,
                        Reason = "It's much needed",
                        Status = "Pending"
                    },
                    new Request
                    {
                        Name = "Jane Doe",
                        Email = "jdoe@saltandlight.technology",
                        ApproverEmail = "admin@saltandlight.technology",
                        RequestType = "Sick",
                        LeaveDateTime = DateTime.Now,
                        ReturnDateTime = DateTime.Now,
                        Reason = "Cold",
                        Status = "Approved"
                    },
                    new Request
                    {
                        Name = "Jay Freeman",
                        Email = "jfreeman@saltandlight.technology",
                        ApproverEmail = "admin@saltandlight.technology",
                        RequestType = "Jury Duty",
                        LeaveDateTime = DateTime.Now,
                        ReturnDateTime = DateTime.Now,
                        Reason = "Got jury summons",
                        Status = "Approved"
                    },
                    new Request
                    {
                        Name = "Jimmy Taylor",
                        Email = "jtaylor@saltandlight.technology",
                        ApproverEmail = "admin@saltandlight.technology",
                        RequestType = "Vacation",
                        LeaveDateTime = DateTime.Now,
                        ReturnDateTime = DateTime.Now,
                        Reason = "",
                        Status = "Declined"
                    },
                    new Request
                    {
                        Name = "Xelyk Xyran",
                        Email = "xxyran@saltandlight.technology",
                        ApproverEmail = "admin@saltandlight.technology",
                        RequestType = "Exempt - Less than 8 hours",
                        LeaveDateTime = DateTime.Now,
                        ReturnDateTime = DateTime.Now,
                        Reason = "Need to run some errands",
                        Status = "Canceled"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}