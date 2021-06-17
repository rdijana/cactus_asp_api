using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UseCaseLogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Actor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UseCaseName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Data = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UseCaseLogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PostCategories",
                columns: table => new
                {
                    PostId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostCategories", x => new { x.PostId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_PostCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PostCategories_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comments_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Marks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    PostId = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Marks_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Marks_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserUseCases",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    UseCaseId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserUseCases", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserUseCases_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "IsActive", "IsDeleted", "ModifiedAt", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, false, null, " Planting cactus " },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, false, null, "Cactus care" },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, false, null, "Growing cactus" }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "Content", "CreatedAt", "DeletedAt", "Description", "Image", "IsActive", "IsDeleted", "ModifiedAt", "Title" },
                values: new object[,]
                {
                    { 1, "From spring to autumn, that is. cacti need as much light as possible during the growing season. A place where\r\n                    we intend to grow cacti we have to choose so that the plants are as long as possible\r\n                    illuminated by the sun. This should be prevented. albeit temporarily, shading\r\n                    cactus with some trees, buildings, etc. The ideal place for cacti is the one that\r\n                    the sun shines as soon as it rises, but that it can shine on them even when it sets. That's right\r\n                    there are not many ideal places, especially in cities. However, and at\r\n                    in the half-day sun, it is possible to successfully cultivate many beautiful species. The morning sun is always more favorable than the afternoon. That's why they are\r\n                    better southeastern than southwestern positions, etc. If we have to collect\r\n                    set to the northeast or northwest, then they must be chosen only\r\n                    those species that can bear it. Certainly with the right choice, and it is possible here\r\n                    achieve good results. <br/> <br/>\r\n                    The cactus under the window has only about 10% of daylight. a\r\n                    if grown outside the window, it already gets 50% of that light. That's a big difference.\r\n                    If the cactus is grown on the flat roof of a tall building, the plant\r\n                    will dispose of\r\n                    all 100% of the light is reflected from the horizon and will be directly illuminated by the sun. <br/> <br/>\r\n                    The intensity of the lights is also affected by the location, altitude, proximity to the factory, etc.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Light, in this post I will briefly explain to you the importance of natural light for growing cacti.", "svetlost.jpg", false, false, null, "Light" },
                    { 2, "The suitability of water for irrigation depends on the amount of minerals that are in\r\n                   dissolved to her. That's why we talk about soft water. which contains little dissolved\r\n                   mineral salts, and about hard when it contains more. The amount of minerals\r\n                   contained in water are expressed in degrees of hardness. The so-called the German scale has 30\r\n                   degrees. The softest is distilled water, followed by rainwater. Surface water from\r\n                   streams, rivers and ponds are harder, and well water is often very hard. Water\r\n                   for watering cacti do not deer be harder than 4 degrees of German scale. Hardness\r\n                   waters usually form lime salts - carbonates.Frequent watering with salt\r\n                   they accumulate in the substrate and make it alkaline. If the pH value of the substance\r\n                   increase to 8 - cacti stop growing. Therefore, rainwater is considered the best for watering cacti. However.and it can be unclean, especially in larger ones\r\n                   cities.Ideally, rainwater would be filtered through filtered filters\r\n                   activated carbon.This would remove dissolved hydrogen sulfide, sulfur\r\n                   oxide, various tar substances and coarser ash particles.Most florists are,\r\n                   however, directed to tap water - hence hard water.Hardness\r\n                   can be significantly reduced by cooking.If peat is used, then it is\r\n                   the negative effect of hard water is much less. Water must also be acidic\r\n                   reaction, which is discussed in more detail in the section on hydroponics.If we are\r\n                   yet forced to use hard water, we need cacti every year\r\n                   transplant.When we have a lot of cacti, we usually water them from a tin can\r\n                   or directly by means of a rubber hose with a sprayed rose planted\r\n                   water.It's so much faster. but even that has its downside, because the whole plant\r\n                   wet, which diminishes its beautiful appearance.Most importantly, fine wool is sapped\r\n                   which some cacti create in axillae, or on a vegetation heap.On the green\r\n                   plants appear then a gray layer that spoils their appearance, and when\r\n                   appearing to a greater extent can clog the stoma.Therefore, it is better to water the cacti from\r\n                   buckets with a pipe so that the body of the cactus does not get wet.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Watering, in this post I will let you write about the important things related to watering.", "zalivanje.jpg", false, false, null, "Watering" },
                    { 3, "The pleasure we feel when we have a beautiful collection of cacti\r\n                            it is common\r\n                            disturbed by the appearance of various diseases and pests,\r\n                            whose number is large. It should be done immediately\r\n                            emphasize that cacti in collections to which appropriate attention is paid and\r\n                            they resist diseases and pests much better than neglected, bad ones\r\n                            fed or inadequate\r\n                            I will place the collection, where the light and\r\n                            thermal conditions do not meet the needs of healthy growth. Sometimes some\r\n                            wrong procedure, for example excessive watering, can lead to harmful\r\n                            Consequences. Diseases and pests mostly attack weakened plants. If\r\n                            applies and good care, cacti during the winter must be in for a long time\r\n                            vegetation dormancy. Many cacti stop growing during the summer heat\r\n                            Such stagnation in vegetation means a certain reduction in resistance against many\r\n                            diseases and pests. Therefore, diseases and pests can also appear for good\r\n                            nurtured collections. <br />\r\n                            The basic precondition for a successful fight against pests and diseases is theirs\r\n                            timely detection. It is not always easy, especially when it comes to diseases\r\n                            caused by fungi or viruses.In most cases, the amateur florist does not\r\n                            can get to know all diseases and pests in detail. There is a wide field here\r\n                            activities of young mycologists, virologists and entomologists.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "In this post, I will write you how to protect cacti from pests.", "prehrana.jpg", false, false, null, "Protection" },
                    { 4, "<b> 1. </b> Fill a small pot about 5 cm deep with cactus substrate, but not to the top, leave 1-2 cm of the pot empty. The seeds are best sown in a mixture of crushed brick and sand 1: 1, with the addition of pressed natural peat or mix the purchased soil with quartz sand. It is mandatory that the pot has drainage holes in the bottom. <br/>\r\n                     <b> Substrate preparation: </b> The substrate should be disinfected and you can do it on steam for at least one hour, baking in the oven for 30-60 minutes, where the temperature should not exceed 150 ° C because it destroys nutrients and humus or in the microwave for about 5 minutes at maximum. <br/>\r\n<b> Seed preparation: </b> Seeds must be clean and if there are any remains of the plant, they should be removed. It is also good to dust the seeds with a fungicide against mold before sowing. Place the seeds in a glass tube and add a product containing TMTD (tetramethyl-thiuram-disulfide), close the tube and shake to dust the seeds. <br/>\r\n<b> 2. </b> Sprinkle the seeds on the ground, making sure that it is not too thick, and then lightly press the substrate so that the seeds remain on the surface. You can add a thin layer of vermiculite over it.\r\n<br/>\r\n<b> 3. </b> The substrate in which we plant the seeds should be moist, so water it with boiled water to which you can add a fungicide.\r\n<br/>\r\n<b>\r\n4. </b> Cover the pot with a clear plastic bag or glass and leave at a temperature of 25 - 30 ° C. Do not leave it in direct sunlight and keep the soil moist.\r\n<br/>\r\n<b> 5. </b> Shoots will appear in a few weeks. Gradually remove the glass or nylon so that the plants get used to the external conditions. In 3-5 months you have small plants ready to dive.\r\n<br/>\r\n<b> 6. </b> Prepare a dive bowl and fill with the same mixture as when sowing. The soil should be moistened and holes made for the plants. Carefully plant the shoots in the holes, water them and leave them in a sunny place. Transplant further as needed.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "In this post, I will explain the procedure of planting cactus by seed.", "semeSadnja.jpg", false, false, null, "How to plant cactus seeds?" },
                    { 5, "The cutting is the part of the plant that is separated from the parent plant by cutting.\r\nWith a squid knife (scalpel), we cut those cuttings that are otherwise difficult\r\nseparate. If we separated them by force, we could rip out a long piece\r\nconductive bundles from the body of the parent plant and thus it is unnecessary to damage. Like this\r\ncuttings can easily and practically multiply many species of cacti. Since\r\non the cutting the injury is bigger, it is good to disinfect it immediately after separation,\r\nbecause the place where the incision was made could become an entrance for infection. We nurture,\r\nhence, both the wound on the parent plant and on the cuttings. Earlier for disinfection\r\nused charcoal or gypsum powder - which he created on the wound\r\nsolid\r\na coating that could peel off after the wound has healed. It is now known that there are many\r\nbetter to use aluminum powder. We apply it\r\nbrush directly on\r\ncut surface. The powder sticks to the wet surface and creates a layer that mechanically and\r\nchemically prevents infection. <br/>\r\nWe do not plant cuttings as quickly as shoots. The wound must dry well, it must\r\ncreate a callus, and in addition the cuttings must get enough time to\r\nrooted. We should not be afraid to leave the cuttings unplanted until they are\r\nthe beginnings of the root appear. It depends on the temperature and the type of plant, so it lasts from 10 to\r\n30 days. Cuttings are best rooted in the spring, when the vegetation begins.\r\nWe can separate them from the parent plant as early as the end of winter. Stem plants and\r\ncuttings are usually placed above the radiator or central heating pipe, where it is\r\nwarm and dry. We have to be careful not to get burned. The cuttings must be in the same\r\nposition in what\r\nwill be when planting. If we allow the cuttings\r\nprickly pears or cerus lie, those\r\nwill be distorted. Later they are hard to plant, and formed\r\nthe deformation can no longer be corrected. It often happens that the root does not grow there\r\nwhere necessary - veins already appear along the entire length of the stem that lies.\r\nSo it is best to put the cuttings in a pot wide enough, and if necessary,\r\nsecure them in an upright position with crumpled paper.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "In this post, I will explain to you the procedure of planting a cactus by cuttings.", "reznica.jpg", false, false, null, "How to plant a cactus by cuttings?" },
                    { 6, "Shoots are parts of the plant that grew from an areola or axilla of an older cactus.\r\nSometimes a touch is enough to separate the shoot from the parent plant. That\r\nwe can best observe in one of the most famous species - Echinopsis\r\neyriesii. Quite conspicuous, prickly balls grow on the areolas. Easy them\r\nwe tear off and see that they were only attached to a thin tube of conductive\r\nbundles. After the separation, only a small wound remained, next to which\r\nOften\r\nwe notice already well-developed roots. After planting and rooting shoot\r\ngrows normally, as a stand-alone plant. <br/>\r\nThis way of reproduction is called vegetative, unlike\r\ngenerative propagation, when a new plant sprouts from seed. Pri\r\nvegetative propagation of all plants sprouted from one parent plant by\r\nthe properties are similar. In foreign fertilized cacti by mutual pollination\r\nshoots from the same mother plant did not produce seeds. There are species that create\r\nso many shoots that it is superfluous to grow them from seed. <br/>\r\nA special phenomenon are the underground shoots. That's how we talk about moles code\r\nNotocactus ottonis. They occur on the underside of the plant, ie underground. U\r\nthe original form is brown in color. Given the place of origin, shape and color\r\nare really somewhat similar to miniature tubers. <br/>\r\n Separated\r\nlet the shoot lie for a day or two in a warm, dry and cool place to\r\nseparation injury healed.Then we plant the plant in the ground, where\r\nit soon takes root and begins to grow independently.If we plant on a granular substrate, ie.\r\nto hydroponics.shoots must be planted deeper so that the growing root does not rise.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "In this post, I will explain to you the procedure of planting a cactus with a shoot.", "izdanak.jpg", false, false, null, "How to plant a cactus with a shoot?" },
                    { 7, "We usually transplant cacti in the spring. We can transplant them not only in the spring, but also at the end of summer stagnation, ie.\r\nin late July and early August. For cacti that bloom in the spring - that's it\r\nbetter. All plants were transplanted at the mentioned time until autumn\r\nthey grow well, often better than those we have not transplanted. Some florists usually\r\ntransplant the entire collection during the summer,\r\nthus saving themselves the job of spring\r\ntransplantation. Some others transplant cacti\r\neven twice - in the spring, and in\r\nautumn - and achieve good results. <br/>\r\n<b> Procedure: </b>\r\n<br/>\r\nTo remove the cactus from the pot, turn it upside down and hit its edge or side until the substrate separates from the pot. If you have difficulty, use a thin object to separate it from the edges of the pot.\r\n<br/>\r\nClean the root from the ground and untangle it, but be careful not to damage it too much. Plant in a new pot that is a little bigger than the previous one, with the obligatory drainage layer of pebbles or broken bricks at the bottom. Make sure that the root is not bent, ie. to be evenly distributed throughout the pot.\r\n<br/>\r\n\r\nThe transplanted cactus should not be watered for the next 7-10 days, and it should not be overdone during the first watering.\r\n<br/>\r\nFor safe handling of cacti do not forget to protect your hands with rubber or garden gloves.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "In this post, I will address the topic of cactus transplanting.", "presadjivanje.jpg", false, false, null, "Transplantation" },
                    { 8, "It is wisest for beginners to buy a substrate for cacti, and they should choose those that are based on peat, have a lot of quartz sand or coconut fiber. Be sure to add coarse sand or pebbles to make the substrate porous. <br/> <br/>\r\nThe substrate should contain half of pebbles and coarse sand. It would be ideal to transplant younger plants every year in the spring to provide them with fresh substrate and a place to grow. This is useful because it is important to inspect the roots regularly for possible diseases or woolly root lice. <br/> <br/>\r\nIn terms of chemical composition, the soil should contain: <br/>\r\nNPK nitrogen phosphorus potassium <br/>\r\nCalcium <br/>\r\nC- carbon <br/>\r\nH- hydrogen <br/>\r\nO-oxygen <br/>\r\nTrace elements <br/>\r\n<br/>\r\nThe chemical reaction of the substrate for cacti and succulents is also very important, because it must not be too acidic or too alkaline. Most fit the pH around 6-6.5. At a value of PH 8 cacti stop growing and thriving.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "In this post, I will write about what kind of land is needed for growing cacti.", "zemlja.jpg", false, false, null, "Land" },
                    { 9, "There are usually two types of pots available, ceramic and plastic. Breeders use both depending on personal affinities.\r\n<br/>\r\nPlastic pots are lighter, cheaper, require less watering and are easy to wash. Clay pots can provide stability to tall plants and help reduce the effects of excessive watering, but their heavier weight requires strong shelves.\r\n<br/>\r\nBonsai pots can look effective with caudex plants. Finally, some cacti and succulents in nature inhabit limestone terrains where they can be seen growing in rock crevices. These plants are suitable for planting in limestone and can look attractive as a replacement for plants planted in alpinetums. <br/>\r\nShallower pots are good for most globular species, as they do not need much space for roots, as is the case with columnar species. Columnar species thrive best in pots one-third to one-half the diameter of the plant. <br/>\r\nThe vessel must have a hole for draining water (drainage). A piece of brick or some net should be placed over the drainage hole to prevent the substrate from spilling out of the container.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "I will briefly describe to you which pots are used for cacti.", "saksije.jpg", false, false, null, "Pots" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "Email", "FirstName", "IsActive", "IsDeleted", "LastName", "ModifiedAt", "Password" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "mara@gmail.com", "Mara", false, false, "Maric", null, "/3NpZnJhMTIz" },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "lara@gmail.com", "Lara", false, false, "Lazic", null, "/3NpZnJhMTIz" }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "Content", "CreatedAt", "DeletedAt", "IsActive", "IsDeleted", "ModifiedAt", "PostId", "UserId" },
                values: new object[,]
                {
                    { 2, "Very nice", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, false, null, 3, 2 },
                    { 1, "Nice", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, false, null, 2, 2 }
                });

            migrationBuilder.InsertData(
                table: "Marks",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "IsActive", "IsDeleted", "ModifiedAt", "PostId", "UserId", "Value" },
                values: new object[,]
                {
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, false, null, 4, 2, 5 },
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, false, null, 5, 2, 4 }
                });

            migrationBuilder.InsertData(
                table: "PostCategories",
                columns: new[] { "CategoryId", "PostId" },
                values: new object[,]
                {
                    { 3, 9 },
                    { 1, 9 },
                    { 3, 8 },
                    { 2, 7 },
                    { 1, 7 },
                    { 2, 8 },
                    { 2, 5 },
                    { 1, 4 },
                    { 3, 4 },
                    { 2, 3 },
                    { 1, 3 },
                    { 3, 2 },
                    { 1, 2 },
                    { 2, 1 },
                    { 3, 6 },
                    { 1, 1 }
                });

            migrationBuilder.InsertData(
                table: "UserUseCases",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "IsActive", "IsDeleted", "ModifiedAt", "UseCaseId", "UserId" },
                values: new object[,]
                {
                    { 21, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, false, null, 21, 1 },
                    { 22, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, false, null, 22, 1 },
                    { 23, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, false, null, 23, 1 },
                    { 24, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, false, null, 24, 1 },
                    { 25, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, false, null, 25, 1 },
                    { 31, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, false, null, 15, 2 },
                    { 27, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, false, null, 11, 2 },
                    { 28, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, false, null, 12, 2 },
                    { 29, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, false, null, 13, 2 },
                    { 30, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, false, null, 14, 2 },
                    { 20, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, false, null, 20, 1 },
                    { 26, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, false, null, 10, 2 },
                    { 19, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, false, null, 19, 1 },
                    { 11, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, false, null, 11, 1 },
                    { 17, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, false, null, 17, 1 },
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, false, null, 1, 1 },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, false, null, 2, 1 },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, false, null, 3, 1 },
                    { 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, false, null, 4, 1 },
                    { 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, false, null, 5, 1 },
                    { 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, false, null, 6, 1 },
                    { 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, false, null, 7, 1 }
                });

            migrationBuilder.InsertData(
                table: "UserUseCases",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "IsActive", "IsDeleted", "ModifiedAt", "UseCaseId", "UserId" },
                values: new object[,]
                {
                    { 18, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, false, null, 18, 1 },
                    { 8, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, false, null, 8, 1 },
                    { 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, false, null, 10, 1 },
                    { 32, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, false, null, 18, 2 },
                    { 12, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, false, null, 12, 1 },
                    { 13, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, false, null, 13, 1 },
                    { 14, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, false, null, 14, 1 },
                    { 15, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, false, null, 15, 1 },
                    { 16, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, false, null, 16, 1 },
                    { 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, false, null, 9, 1 },
                    { 33, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, false, null, 19, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_Name",
                table: "Categories",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comments_PostId",
                table: "Comments",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserId",
                table: "Comments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Marks_PostId",
                table: "Marks",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Marks_UserId",
                table: "Marks",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PostCategories_CategoryId",
                table: "PostCategories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_Title",
                table: "Posts",
                column: "Title",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserUseCases_UserId",
                table: "UserUseCases",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Marks");

            migrationBuilder.DropTable(
                name: "PostCategories");

            migrationBuilder.DropTable(
                name: "UseCaseLogs");

            migrationBuilder.DropTable(
                name: "UserUseCases");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
