using CharityEvents.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CharityEvents.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {

                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();//reference to the database

                context.Database.EnsureCreated();//make sure that the db exist

                //Events
                if (!context.Events.Any()) //check if it is empty
                {
                    context.Events.AddRange(new List<Event>()
                    {
                        new Event()
                        {
                            EventName = "Rapsodia Brasov",
                            Logo = "",
                            EventPeriod = DateTime.Now.AddDays(30),
                            Description="Event caritabil cu scopul de a strange bani pentru diferite cauze sociale"
                        } ,

                        new Event()
                        {
                            EventName = "Primavara Clujana",
                            Logo = "",
                            EventPeriod = DateTime.Now.AddDays(40),
                            Description="Event caritabil cu scopul de a strange bani pentru diferite cauze sociale"
                        }
                    });
                    context.SaveChanges();
                }

                //CharityCauses
                if (!context.CharityCauses.Any())
                {
                    context.CharityCauses.AddRange(new List<CharityCause>()
                    {
                        new CharityCause()
                        {
                            Name = "Renovare etaj 7 spitalul Floreasca",
                            Image = "",
                            Description = "Renovarea si dotarea sectiei x"
                        },

                        new CharityCause()
                        {
                            Name = "Ajutarea comunitatii de ucrainieni ajunse in romania",
                            Image = "",
                            Description = "Ajutarea cu alimente si produse de baza pentru acestia"
                        },

                        new CharityCause()
                        {
                            Name = "Interventie medicala turcia",
                            Image = "",
                            Description = "Strangere de fonduri pentru ajutarea copiilor care necesita interventie medicala in alta tara"
                        }
                    });
                    context.SaveChanges();

                }

                //Bands
                if (!context.Bands.Any())
                {
                    context.Bands.AddRange(new List<Band>()
                    {
                        new Band()
                        {
                            Name="Iris",
                            BandMembers="Cristi Minculescu, Nutu Olteanu, Nelu Dumitrescu, Emil Lechințeanu",
                            Description="Iris este o formație românească de muzică rock, înființată în anul 1977 la București.",
                            DonationPrice = 10,
                            Logo="",
                            ConcertDate = DateTime.Now.AddDays(30),
                            BandCategory = BandCategory.Rock,
                            CharityCauseId = 1
                        },
                        new Band()
                        {
                            Name="3 Sud Est",
                            BandMembers="Mihai Budeanu, Laurentiu Duta, Viorel Sipos",
                            Description="3 Sud Est este o formație românească de muzică pop, formată în data de 17 septembrie 1997.",
                            DonationPrice = 10,
                            Logo="",
                            ConcertDate = DateTime.Now.AddDays(40),
                            BandCategory = BandCategory.Pop,
                            CharityCauseId = 2
                        },
                        new Band()
                        {
                            Name="Bug Mafia",
                            BandMembers="Tataee, Caddy, Uzzy",
                            Description="B.U.G. Mafia este o trupă de hip-hop din România fondată în anul 1993.",
                            DonationPrice = 10,
                            Logo="",
                            ConcertDate = DateTime.Now.AddDays(40),
                            BandCategory = BandCategory.HipHop,
                            CharityCauseId = 3
                        }
                    });
                    context.SaveChanges();

                }

                //Event_Band
                if (!context.Events_Bands.Any())
                {
                    context.Events_Bands.AddRange(new List<Event_Band>()
                    {
                        new Event_Band()
                        {
                            EventId=1,
                            BandId=1
                        },

                       new Event_Band()
                        {
                            EventId=1,
                            BandId=3
                        },

                       new Event_Band()
                        {
                            EventId=2,
                            BandId=2
                        }
                    });
                    context.SaveChanges();

                }


            }
        }
    }
}
