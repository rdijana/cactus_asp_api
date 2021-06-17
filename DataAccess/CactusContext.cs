using Cactus.DataAccess.Configurations;
using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess
{
    public class CactusContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var categories = new List<Category> {
            new Category{Id=1,Name=" Planting cactus "},
            new Category{Id=2,Name="Cactus care"},
            new Category{Id=3,Name="Growing cactus"}
            };

            var posts = new List<Post>
            {
            new Post{
                    Id=1,
                    Title="Light",
                    Description="Light, in this post I will briefly explain to you the importance of natural light for growing cacti.",
                    Content=@"From spring to autumn, that is. cacti need as much light as possible during the growing season. A place where
                    we intend to grow cacti we have to choose so that the plants are as long as possible
                    illuminated by the sun. This should be prevented. albeit temporarily, shading
                    cactus with some trees, buildings, etc. The ideal place for cacti is the one that
                    the sun shines as soon as it rises, but that it can shine on them even when it sets. That's right
                    there are not many ideal places, especially in cities. However, and at
                    in the half-day sun, it is possible to successfully cultivate many beautiful species. The morning sun is always more favorable than the afternoon. That's why they are
                    better southeastern than southwestern positions, etc. If we have to collect
                    set to the northeast or northwest, then they must be chosen only
                    those species that can bear it. Certainly with the right choice, and it is possible here
                    achieve good results. <br/> <br/>
                    The cactus under the window has only about 10% of daylight. a
                    if grown outside the window, it already gets 50% of that light. That's a big difference.
                    If the cactus is grown on the flat roof of a tall building, the plant
                    will dispose of
                    all 100% of the light is reflected from the horizon and will be directly illuminated by the sun. <br/> <br/>
                    The intensity of the lights is also affected by the location, altitude, proximity to the factory, etc.",
                    Image="svetlost.jpg"
                },
            new Post
                {
                   Id=2,
                   Title="Watering",
                   Description="Watering, in this post I will let you write about the important things related to watering.",
                   Content=@"The suitability of water for irrigation depends on the amount of minerals that are in
                   dissolved to her. That's why we talk about soft water. which contains little dissolved
                   mineral salts, and about hard when it contains more. The amount of minerals
                   contained in water are expressed in degrees of hardness. The so-called the German scale has 30
                   degrees. The softest is distilled water, followed by rainwater. Surface water from
                   streams, rivers and ponds are harder, and well water is often very hard. Water
                   for watering cacti do not deer be harder than 4 degrees of German scale. Hardness
                   waters usually form lime salts - carbonates.Frequent watering with salt
                   they accumulate in the substrate and make it alkaline. If the pH value of the substance
                   increase to 8 - cacti stop growing. Therefore, rainwater is considered the best for watering cacti. However.and it can be unclean, especially in larger ones
                   cities.Ideally, rainwater would be filtered through filtered filters
                   activated carbon.This would remove dissolved hydrogen sulfide, sulfur
                   oxide, various tar substances and coarser ash particles.Most florists are,
                   however, directed to tap water - hence hard water.Hardness
                   can be significantly reduced by cooking.If peat is used, then it is
                   the negative effect of hard water is much less. Water must also be acidic
                   reaction, which is discussed in more detail in the section on hydroponics.If we are
                   yet forced to use hard water, we need cacti every year
                   transplant.When we have a lot of cacti, we usually water them from a tin can
                   or directly by means of a rubber hose with a sprayed rose planted
                   water.It's so much faster. but even that has its downside, because the whole plant
                   wet, which diminishes its beautiful appearance.Most importantly, fine wool is sapped
                   which some cacti create in axillae, or on a vegetation heap.On the green
                   plants appear then a gray layer that spoils their appearance, and when
                   appearing to a greater extent can clog the stoma.Therefore, it is better to water the cacti from
                   buckets with a pipe so that the body of the cactus does not get wet.",
                   Image="zalivanje.jpg"
                },
                new Post
                {
                    Id=3,
                    Title="Protection",
                    Description="In this post, I will write you how to protect cacti from pests.",
                    Content=@"The pleasure we feel when we have a beautiful collection of cacti
                            it is common
                            disturbed by the appearance of various diseases and pests,
                            whose number is large. It should be done immediately
                            emphasize that cacti in collections to which appropriate attention is paid and
                            they resist diseases and pests much better than neglected, bad ones
                            fed or inadequate
                            I will place the collection, where the light and
                            thermal conditions do not meet the needs of healthy growth. Sometimes some
                            wrong procedure, for example excessive watering, can lead to harmful
                            Consequences. Diseases and pests mostly attack weakened plants. If
                            applies and good care, cacti during the winter must be in for a long time
                            vegetation dormancy. Many cacti stop growing during the summer heat
                            Such stagnation in vegetation means a certain reduction in resistance against many
                            diseases and pests. Therefore, diseases and pests can also appear for good
                            nurtured collections. <br />
                            The basic precondition for a successful fight against pests and diseases is theirs
                            timely detection. It is not always easy, especially when it comes to diseases
                            caused by fungi or viruses.In most cases, the amateur florist does not
                            can get to know all diseases and pests in detail. There is a wide field here
                            activities of young mycologists, virologists and entomologists.",
                    Image="prehrana.jpg"
                },
                new Post
                {
                    Id=4,
                    Title="How to plant cactus seeds?",
                    Description="In this post, I will explain the procedure of planting cactus by seed.",
                    Content=@"<b> 1. </b> Fill a small pot about 5 cm deep with cactus substrate, but not to the top, leave 1-2 cm of the pot empty. The seeds are best sown in a mixture of crushed brick and sand 1: 1, with the addition of pressed natural peat or mix the purchased soil with quartz sand. It is mandatory that the pot has drainage holes in the bottom. <br/>
                     <b> Substrate preparation: </b> The substrate should be disinfected and you can do it on steam for at least one hour, baking in the oven for 30-60 minutes, where the temperature should not exceed 150 ° C because it destroys nutrients and humus or in the microwave for about 5 minutes at maximum. <br/>
<b> Seed preparation: </b> Seeds must be clean and if there are any remains of the plant, they should be removed. It is also good to dust the seeds with a fungicide against mold before sowing. Place the seeds in a glass tube and add a product containing TMTD (tetramethyl-thiuram-disulfide), close the tube and shake to dust the seeds. <br/>
<b> 2. </b> Sprinkle the seeds on the ground, making sure that it is not too thick, and then lightly press the substrate so that the seeds remain on the surface. You can add a thin layer of vermiculite over it.
<br/>
<b> 3. </b> The substrate in which we plant the seeds should be moist, so water it with boiled water to which you can add a fungicide.
<br/>
<b>
4. </b> Cover the pot with a clear plastic bag or glass and leave at a temperature of 25 - 30 ° C. Do not leave it in direct sunlight and keep the soil moist.
<br/>
<b> 5. </b> Shoots will appear in a few weeks. Gradually remove the glass or nylon so that the plants get used to the external conditions. In 3-5 months you have small plants ready to dive.
<br/>
<b> 6. </b> Prepare a dive bowl and fill with the same mixture as when sowing. The soil should be moistened and holes made for the plants. Carefully plant the shoots in the holes, water them and leave them in a sunny place. Transplant further as needed.",
                    Image="semeSadnja.jpg"
                },
                 new Post
                {
                    Id=5,
                    Title="How to plant a cactus by cuttings?",
                    Description="In this post, I will explain to you the procedure of planting a cactus by cuttings.",
                    Content=@"The cutting is the part of the plant that is separated from the parent plant by cutting.
With a squid knife (scalpel), we cut those cuttings that are otherwise difficult
separate. If we separated them by force, we could rip out a long piece
conductive bundles from the body of the parent plant and thus it is unnecessary to damage. Like this
cuttings can easily and practically multiply many species of cacti. Since
on the cutting the injury is bigger, it is good to disinfect it immediately after separation,
because the place where the incision was made could become an entrance for infection. We nurture,
hence, both the wound on the parent plant and on the cuttings. Earlier for disinfection
used charcoal or gypsum powder - which he created on the wound
solid
a coating that could peel off after the wound has healed. It is now known that there are many
better to use aluminum powder. We apply it
brush directly on
cut surface. The powder sticks to the wet surface and creates a layer that mechanically and
chemically prevents infection. <br/>
We do not plant cuttings as quickly as shoots. The wound must dry well, it must
create a callus, and in addition the cuttings must get enough time to
rooted. We should not be afraid to leave the cuttings unplanted until they are
the beginnings of the root appear. It depends on the temperature and the type of plant, so it lasts from 10 to
30 days. Cuttings are best rooted in the spring, when the vegetation begins.
We can separate them from the parent plant as early as the end of winter. Stem plants and
cuttings are usually placed above the radiator or central heating pipe, where it is
warm and dry. We have to be careful not to get burned. The cuttings must be in the same
position in what
will be when planting. If we allow the cuttings
prickly pears or cerus lie, those
will be distorted. Later they are hard to plant, and formed
the deformation can no longer be corrected. It often happens that the root does not grow there
where necessary - veins already appear along the entire length of the stem that lies.
So it is best to put the cuttings in a pot wide enough, and if necessary,
secure them in an upright position with crumpled paper.",
                    Image="reznica.jpg"
                },
                  new Post
                {
                    Id=6,
                    Title="How to plant a cactus with a shoot?",
                    Description="In this post, I will explain to you the procedure of planting a cactus with a shoot.",
                    Content=@"Shoots are parts of the plant that grew from an areola or axilla of an older cactus.
Sometimes a touch is enough to separate the shoot from the parent plant. That
we can best observe in one of the most famous species - Echinopsis
eyriesii. Quite conspicuous, prickly balls grow on the areolas. Easy them
we tear off and see that they were only attached to a thin tube of conductive
bundles. After the separation, only a small wound remained, next to which
Often
we notice already well-developed roots. After planting and rooting shoot
grows normally, as a stand-alone plant. <br/>
This way of reproduction is called vegetative, unlike
generative propagation, when a new plant sprouts from seed. Pri
vegetative propagation of all plants sprouted from one parent plant by
the properties are similar. In foreign fertilized cacti by mutual pollination
shoots from the same mother plant did not produce seeds. There are species that create
so many shoots that it is superfluous to grow them from seed. <br/>
A special phenomenon are the underground shoots. That's how we talk about moles code
Notocactus ottonis. They occur on the underside of the plant, ie underground. U
the original form is brown in color. Given the place of origin, shape and color
are really somewhat similar to miniature tubers. <br/>
 Separated
let the shoot lie for a day or two in a warm, dry and cool place to
separation injury healed.Then we plant the plant in the ground, where
it soon takes root and begins to grow independently.If we plant on a granular substrate, ie.
to hydroponics.shoots must be planted deeper so that the growing root does not rise.",
                    Image="izdanak.jpg"
                },
                   new Post
                {
                    Id=7,
                    Title="Transplantation",
                    Description="In this post, I will address the topic of cactus transplanting.",
                    Content=@"We usually transplant cacti in the spring. We can transplant them not only in the spring, but also at the end of summer stagnation, ie.
in late July and early August. For cacti that bloom in the spring - that's it
better. All plants were transplanted at the mentioned time until autumn
they grow well, often better than those we have not transplanted. Some florists usually
transplant the entire collection during the summer,
thus saving themselves the job of spring
transplantation. Some others transplant cacti
even twice - in the spring, and in
autumn - and achieve good results. <br/>
<b> Procedure: </b>
<br/>
To remove the cactus from the pot, turn it upside down and hit its edge or side until the substrate separates from the pot. If you have difficulty, use a thin object to separate it from the edges of the pot.
<br/>
Clean the root from the ground and untangle it, but be careful not to damage it too much. Plant in a new pot that is a little bigger than the previous one, with the obligatory drainage layer of pebbles or broken bricks at the bottom. Make sure that the root is not bent, ie. to be evenly distributed throughout the pot.
<br/>

The transplanted cactus should not be watered for the next 7-10 days, and it should not be overdone during the first watering.
<br/>
For safe handling of cacti do not forget to protect your hands with rubber or garden gloves.",
                    Image="presadjivanje.jpg"
                }, new Post
                {
                    Id=8,
                    Title="Land",
                    Description="In this post, I will write about what kind of land is needed for growing cacti.",
                    Content=@"It is wisest for beginners to buy a substrate for cacti, and they should choose those that are based on peat, have a lot of quartz sand or coconut fiber. Be sure to add coarse sand or pebbles to make the substrate porous. <br/> <br/>
The substrate should contain half of pebbles and coarse sand. It would be ideal to transplant younger plants every year in the spring to provide them with fresh substrate and a place to grow. This is useful because it is important to inspect the roots regularly for possible diseases or woolly root lice. <br/> <br/>
In terms of chemical composition, the soil should contain: <br/>
NPK nitrogen phosphorus potassium <br/>
Calcium <br/>
C- carbon <br/>
H- hydrogen <br/>
O-oxygen <br/>
Trace elements <br/>
<br/>
The chemical reaction of the substrate for cacti and succulents is also very important, because it must not be too acidic or too alkaline. Most fit the pH around 6-6.5. At a value of PH 8 cacti stop growing and thriving.",
                    Image="zemlja.jpg"
                }, new Post
                {
                    Id=9,
                    Title="Pots",
                    Description="I will briefly describe to you which pots are used for cacti.",
                    Content=@"There are usually two types of pots available, ceramic and plastic. Breeders use both depending on personal affinities.
<br/>
Plastic pots are lighter, cheaper, require less watering and are easy to wash. Clay pots can provide stability to tall plants and help reduce the effects of excessive watering, but their heavier weight requires strong shelves.
<br/>
Bonsai pots can look effective with caudex plants. Finally, some cacti and succulents in nature inhabit limestone terrains where they can be seen growing in rock crevices. These plants are suitable for planting in limestone and can look attractive as a replacement for plants planted in alpinetums. <br/>
Shallower pots are good for most globular species, as they do not need much space for roots, as is the case with columnar species. Columnar species thrive best in pots one-third to one-half the diameter of the plant. <br/>
The vessel must have a hole for draining water (drainage). A piece of brick or some net should be placed over the drainage hole to prevent the substrate from spilling out of the container.",
                    Image="saksije.jpg"
                }

            };
            var postCategory = new List<PostCategory>
            {
                new PostCategory{PostId=1,CategoryId=1},
                new PostCategory{PostId=1,CategoryId=2},
                new PostCategory{PostId=2,CategoryId=1},
                new PostCategory{PostId=2,CategoryId=3},
                new PostCategory{PostId=3,CategoryId=1},
                new PostCategory{PostId=3,CategoryId=2},
                new PostCategory{PostId=4,CategoryId=3},
                new PostCategory{PostId=4,CategoryId=1},
                new PostCategory{PostId=5,CategoryId=2},
                new PostCategory{PostId=6,CategoryId=3},
                new PostCategory{PostId=7,CategoryId=1},
                new PostCategory{PostId=7,CategoryId=2},
                new PostCategory{PostId=8,CategoryId=2},
                new PostCategory{PostId=8,CategoryId=3},
                new PostCategory{PostId=9,CategoryId=1},
                new PostCategory{PostId=9,CategoryId=3}
            };
            var user = new List<User>
            {
                new User
                {
                    Id=1,
                    FirstName="Mara",
                    LastName="Maric",
                    Email="mara@gmail.com",
                    Password=HashHelper.ConvertPasswordFormat("sifra123", 0xFF),

                }, new User
                {
                    Id=2,
                    FirstName="Lara",
                    LastName="Lazic",
                    Email="lara@gmail.com",
                    Password=HashHelper.ConvertPasswordFormat("sifra123", 0xFF),
                }
            };
            var userusecase = new List<UserUseCase>
            {
                new UserUseCase{Id=1,UserId=1,UseCaseId=1},
                new UserUseCase{Id=2,UserId=1,UseCaseId=2},
                new UserUseCase{Id=3,UserId=1,UseCaseId=3},
                new UserUseCase{Id=4,UserId=1,UseCaseId=4},
                new UserUseCase{Id=5,UserId=1,UseCaseId=5},
                new UserUseCase{Id=6,UserId=1,UseCaseId=6},
                new UserUseCase{Id=7,UserId=1,UseCaseId=7},
                new UserUseCase{Id=8,UserId=1,UseCaseId=8},
                new UserUseCase{Id=9,UserId=1,UseCaseId=9},
                new UserUseCase{Id=10,UserId=1,UseCaseId=10},
                new UserUseCase{Id=11,UserId=1,UseCaseId=11},
                new UserUseCase{Id=12,UserId=1,UseCaseId=12},
                new UserUseCase{Id=13,UserId=1,UseCaseId=13},
                new UserUseCase{Id=14,UserId=1,UseCaseId=14},
                new UserUseCase{Id=15,UserId=1,UseCaseId=15},
                new UserUseCase{Id=16,UserId=1,UseCaseId=16},
                new UserUseCase{Id=17,UserId=1,UseCaseId=17},
                new UserUseCase{Id=18,UserId=1,UseCaseId=18},
                new UserUseCase{Id=19,UserId=1,UseCaseId=19},
                new UserUseCase{Id=20,UserId=1,UseCaseId=20},
                new UserUseCase{Id=21,UserId=1,UseCaseId=21},
                new UserUseCase{Id=22,UserId=1,UseCaseId=22},
                new UserUseCase{Id=23,UserId=1,UseCaseId=23},
                new UserUseCase{Id=24,UserId=1,UseCaseId=24},
                new UserUseCase{Id=25,UserId=1,UseCaseId=25},
                new UserUseCase{Id=26,UserId=2,UseCaseId=10},
                new UserUseCase{Id=27,UserId=2,UseCaseId=11},
                new UserUseCase{Id=28,UserId=2,UseCaseId=12},
                new UserUseCase{Id=29,UserId=2,UseCaseId=13},
                new UserUseCase{Id=30,UserId=2,UseCaseId=14},
                new UserUseCase{Id=31,UserId=2,UseCaseId=15},
                new UserUseCase{Id=32,UserId=2,UseCaseId=18},
                new UserUseCase{Id=33,UserId=2,UseCaseId=19}
            };

            var comment = new List<Comment>
            {
                new Comment{Id=1,UserId=2,PostId=2,Content="Nice"},
                new Comment{Id=2,UserId=2,PostId=3,Content="Very nice"}
            };

            var mark = new List<Mark>
            {
                new Mark{Id=1,UserId=2,PostId=5,Value=4},
                new Mark{Id=2,UserId=2,PostId=4,Value=5}
            };
            modelBuilder.Entity<Category>().HasData(categories);
            modelBuilder.Entity<Post>().HasData(posts);
            modelBuilder.Entity<PostCategory>().HasData(postCategory);
            modelBuilder.Entity<User>().HasData(user);
            modelBuilder.Entity<UserUseCase>().HasData(userusecase);
            modelBuilder.Entity<Comment>().HasData(comment);
            modelBuilder.Entity<Mark>().HasData(mark);


            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new CommentConfiguration());
            modelBuilder.ApplyConfiguration(new MarkConfiguration());
            modelBuilder.ApplyConfiguration(new PostConfiguration());
            modelBuilder.ApplyConfiguration(new UseCaseLogConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());

            modelBuilder.Entity<Comment>().HasQueryFilter(p => !p.IsDeleted);
            modelBuilder.Entity<Post>().HasQueryFilter(p => !p.IsDeleted);
            modelBuilder.Entity<Category>().HasQueryFilter(p => !p.IsDeleted);
            modelBuilder.Entity<User>().HasQueryFilter(p => !p.IsDeleted);
            modelBuilder.Entity<Mark>().HasQueryFilter(p => !p.IsDeleted);


            modelBuilder.Entity<PostCategory>().HasKey(x => new { x.PostId, x.CategoryId });
        }
        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries())
            {
                if (entry.Entity is Entity e)
                {
                    switch (entry.State)
                    {
                        case EntityState.Added:
                            e.CreatedAt = DateTime.UtcNow;
                            e.IsDeleted = false;
                            e.IsActive = true;
                            e.ModifiedAt = null;
                            e.DeletedAt = null;
                            break;
                        case EntityState.Modified:
                            e.ModifiedAt = DateTime.UtcNow;
                            break;
                    }
                }
            }
            return base.SaveChanges();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-278S2JT\SQLEXPRESS;Initial Catalog=cactusblog;Integrated Security=True");
        }

        public DbSet<User> Users { get; set; }
        public DbSet<UserUseCase> UserUseCases { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Mark> Marks { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<PostCategory> PostCategories { get; set; }
        public DbSet<UseCaseLog> UseCaseLogs { get; set; }
    }
}
