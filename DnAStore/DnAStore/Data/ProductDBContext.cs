﻿using DnAStore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DnAStore.Data
{
    public class ProductDBContext : DbContext
    {

        public ProductDBContext(DbContextOptions<ProductDBContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

			// Seed Products DB
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    ID = 1,
                    Sku = "Eimm/Crat/MPS",
                    Name = "Eimmart A Crater",
                    Price = 1.25m,
                    Description = "Eimmart A, at 4.5 miles(7.3 kilometers) wide, is not large as lunar impact craters go, but its youth and location combine to make it spectacular. Because it is young — excavated by an asteroid or comet impact in the late Copernican, probably less than 100 million years ago — its rim is sharp, its impact melt flows and ponds are obvious, and the boulders strewn over the surface around it are prominent." +
                    "When it comes to rock types, the real estate mantra \"location, location, location\" applies to Eimmart A.The crater, located at 24.12ºN, 65.62ºE, sits on the rim of 25 - mile - wide(40 - kilometer - wide) Eimmart crater, which is in 93 - mile - long(150 - kilometer - long) Mare Anguis(the Serpent Sea), which in turn overlies ejecta from the 345 - mile - wide(555 - kilometer - wide) Mare Crisium impact basin.This means that dark rocks that occur mainly on the east side of Eimmart A are Mare Anguis basalts, while lighter Crisium rocks make up the west side. " +
                    "Eimmart A is \"two-faced\" in other ways. The south and east flanks include many boulders, but melt deposits are small. The north and west flanks include some boulders, but a pair of three-kilometer - long melt flows dominate these areas.The south interior wall includes large outcrops: one triangular outcrop, 600 meters long, is the largest of any found on the Moon in a crater in Eimmart A's size range. The north, east, and west walls have smaller outcrops or none at all. What makes them so different?",
                    Image = @"https://dnastore.blob.core.windows.net/product-image-asset-blob/EimmartACrater.jpg"
				},
                new Product
                {
                    ID = 2,
                    Sku = "Cold/Crat/MPS",
                    Name = "Cold Spot Crater",
                    Price = 1.75m,
                    Description = "Oblique (very!) view of a crater on the far side of the Moon, as imaged by NASA's Lunar Reconnaissance Orbiter (LRO). Known as the Einthoven cold spot crater, it is located at 109.91° E, 6.74° S. White rays and the crater's rocky rim and rugged interior wall are visible signs of youth. A \"cold spot anomaly\" surrounding the crater is another sign of youth. The anomaly extends far beyond the three-kilometer width of this image, but is invisible to human eyes." +
                    "The LRO spacecraft explores the Moon using seven scientific instruments, including the LRO Camera(LROC) package, which obtained this image.The seven instruments collect different kinds of scientific data.Combining their data sets allows scientists to make discoveries they never could if they were limited to a single lunar-orbiting instrument." +
                    "Since 2009, the heat-sensing Diviner Lunar Radiometer Experiment on LRO has systematically mapped the Moon's surface temperatures, enabling reseachers to chart more than 2200 anomalous cold spots between 50° N and 50° S latitude. The cold spot anomalies appear after the Sun goes down." +
                    "The Diviner instrument sees the cold spots as irregular splotches that rapidly radiate heat after sunset until they are up to 10° Fahrenheit colder than the surrounding landscape. LROC, observing in the visible part of the spectrum, sees nothing unusual at cold spot locations. When the Sun rises, the spots rapidly warm to the temperature of their surroundings and blend in with the background." +
                    "What causes cold spot anomalies? In most cases, Diviner data are of too low a resolution to confirm a source.When Diviner data are overlaid on higher - resolution LROC images, however, researchers find that almost all occur around impact craters that are young(less than one million years) and small(from 43 meters to 2300 meters across)." +
                    "We know the craters are young because they have very rocky floors and rims and are surrounded by bright rays. The steady infall of debris from space has not yet had time to chip away these signs of youth.This leads researchers to conclude that a process related to the formation of small craters creates the cold spot anomalies. But what process?" +
                    "Einthoven cold spot crater is 1143 m wide, or about the size of Meteor Crater in Arizona.So far, it has no official name — we call it Einthoven cold spot crater because it is just south of Einthoven crater, which is old, degraded, and, at 69 kilometers in diameter, the largest crater in the neighborhood." +
                    "Though craters associated with cold spot anomalies are small, the cold spots themselves are often large.The Einthoven cold spot crater anomaly takes in 2070 square kilometers of terrain and extends up to 50 kilometers from the crater. That's much too large an area for ejecta from the crater to cover, which eliminates the most obvious cold spot formation hypothesis: that material blasted from the crater during its formation could create the cold spot." +
                    "So, how to explain the cold spot anomalies? Some researchers invoke a cascading series of tiny secondary impacts traveling outward from the crater-forming asteroid impact, while others believe that gas produced by the impact flows through the top layer of lunar surface material. Either process might \"fluff up\" the surface, changing the way heat affects it.Few researchers, however, find these explanations to be 100 % convincing.",
                    Image = @"https://dnastore.blob.core.windows.net/product-image-asset-blob/ColdSpotCrater.jpg"
				},
                new Product
                {
                    ID = 3,
                    Sku = "Gocl/Crat/MPS",
                    Name = "Goclenius Crater",
                    Price = 1.50m,
                    Description = "Goclenius is a lunar impact crater that is located near the west edge of Mare Fecunditatis. It lies to the southeast of the lava-flooded crater Gutenberg, and north of Magelhaens. To the northwest is a parallel rille system that follow a course toward the northwest, running for a length of up to 240 kilometers. This feature is named the Rimae Goclenius." +
                    "The rim of this crater is worn, distorted and irregular, having a somewhat egg - like outline.The crater floor has been covered in lava, and a rille cuts across the floor towards the northwest, in the same direction as the other members of the Rimae Goclenius.A similar rille lies across the floor of Gutenberg, and it is likely that these features were all formed at the same time, after the original craters were created." +
                    "There is a low central rise located to the northwest of the crater's midpoint.",
                    Image = @"https://dnastore.blob.core.windows.net/product-image-asset-blob/GocleniusCrater.jpg"
				},
                new Product
                {
                    ID = 4,
                    Sku = "Aris/Crat/MPS",
                    Name = "Aristarchus Crater",
                    Price = 1.80m,
                    Description = "Due to its spectacular high reflectance rays Aristarchus crater has been a popular landform since telescopes were first pointed towards the Moon. During the Apollo era of exploration much was learned of the wide variety of landforms in this area and it was proposed for a landing site, but the Apollo program was cancelled and humans have yet to visit this fascinating region." +
                    "The Aristarchus crater(about 25 miles or 40 kilometers in diameter) and plateau is one of the most geologically complex areas on the Moon.In this amazing picture, NASA's Lunar Reconnaissance Orbiter spacecraft slewed 62° (west-to-east) looking across the crater.",
                    Image = @"https://dnastore.blob.core.windows.net/product-image-asset-blob/AristarchusCrater.png"
				},
                new Product
                {
                    ID = 5,
                    Sku = "Wall/Crat/MPS",
                    Name = "Wallach Crater",
                    Price = 1.00m,
                    Description = "This spectacular view across the rim of the Moon's Wallach crater, 3.5 miles (5700 meters) across, comes from NASA's Lunar Reconnaissance Orbiter. It was taken when the spacecraft was just 58 miles (93 kilometers) above the surface." +
                    "Wallach crater(4.89°N, 32.27°E) formed within a thin layer of black basaltic lava flows that overlie much brighter anorthositic material.Think of a white cake with chocolate icing.When the asteroid(or comet) impacted this \"iced cake\", ejecta from deeper portions (white cake, or rather brighter anorthosite) was thrown out onto the icing(darker basalt) resulting in intermediate tones where the two materials mixed." +
                    "The dark streaks seen inside the crater are blocks of the icing(basalt) breaking off and creeping down slope. The fact that the deepest material lands on top of the shallowest material(known as inverted stratigraphy) was first described by Gene Shoemaker from his pioneering observations at Meteor Crater, Arizona.This effect simplifies sampling the local geology in three dimensions. As an astronaut traverses towards the rim of a crater, the rocks underfoot come from deeper and deeper within the crater. The rocks at the rim are from the deepest portions of the crater!In effect, nature is providing an easy way to observe and sample materials that would otherwise be buried.",
                    Image = @"https://dnastore.blob.core.windows.net/product-image-asset-blob/WallachCrater.png"
				},
                new Product
                {
                    ID = 6,
                    Sku = "Hawk/Crat/MPS",
                    Name = "Hawke Crater",
                    Price = 1.10m,
                    Description = "Hawke crater, eight miles (13 kilometers) wide, is noticeably tilted because the impactor - an asteroid or a comet - that excavated it struck the sloping inner wall of Grotrian crater. Also visible are light-colored rays that attest to the crater's youth, as well as subtle signs of darker impact melt. This image comes from the LROC camera aboard NASA's Lunar Reconnaissance Orbiter. Image width is about 12 miles (20 kilometers)." +
                    "The International Astronomical Union(IAU), the organization tasked since 1919 with bringing order to astronomical chaos, reviews the names proposed for features in the Solar System.Names must follow established themes.On the Moon, craters are mostly named for lunar scientists, physicists, and astronomers.For example, William Herschel, who discovered Uranus and coined the term \"asteroid,\" has a crater, as does his sister and research partner Caroline Herschel, who discovered eight comets.There are craters named for Albert Einstein, Johannes Kepler, Nicolaus Copernicus, Max Planck, Aristarchus, and many other famous scientists." +
                    "Living scientists are not commemorated on the Moon.Before a scientist’s name can be applied to a crater, she or he must have been deceased for at least two years.This permits a period of calm reflection, during which the community of scientists can consider whether their colleague deserves a place among the immortals." +
                    "In the case of Dr.B.Ray Hawke, who passed away on 24 January 2015, there was no debate about whether a lunar crater should be named for him.B.Ray, as he was known to his many friends, specialized in everything lunar.He was a member of the LROC team and performed lunar remote sensing using Earth - based telescopes.Just as important, he tirelessly mentored lunar scientists as they began and built their careers and dedicated himself to the distribution of lunar data.",
                    Image = @"https://dnastore.blob.core.windows.net/product-image-asset-blob/HawkeCrater.png"
				},
                new Product
                {
                    ID = 7,
                    Sku = "Taur/Vall/MPS",
                    Name = "Taurus-Littrow Valley",
                    Price = 1.45m,
                    Description = "This view of the Taurus-Littrow valley, a geologic exploration target for Apollo 17, comes from the Lunar Reconnaissance Orbiter Camera (LROC) about NASA's Lunar Reconnaissance Orbiter spacecraft. The center latitude is 20.15°N, center longitude 30.98°E. The image is about 11 miles (18 kilometers) wide." +
                    "LROC team scientists, led by Prasun Mahanti, continue their quest to understand the most common class of lunar surface feature: small impact craters.The Moon lacks a protective atmosphere, so objects - mostly bits of asteroids and comets - which would form short-lived meteors or bright fireballs high in Earth's atmosphere survive to strike the Moon's surface and blast out craters.Millions upon millions of small craters pock the lunar surface." +
                    "In a paper published in the planetary science journal Icarus, the Mahanti team reported results of a study of small crater populations at two Apollo sites. The Descartes study area. centered on the Apollo 16 landing point located at 8.9734°S latitude, 15.5011°E longitude, is a highlands site astronauts John Young and Charlie Duke explored in April 1972. The Taurus-Littrow study area, centered on the Apollo 17 landing site at 20.1911°N latitude, 30.7769°E longitude, is a valley on the edge of Mare Serenitatis that astronauts Gene Cernan and Jack Schmitt explored in December 1972." +
                    "LROC has imaged the Apollo 16 and Apollo 17 sites several times under different lighting conditions.So sharp are LROC images that scientists can see the shadows cast by the American flags the astronauts planted at the sites. These images enabled Mahanti's team to examine in great detail craters measuring from 35 to 200 meters wide. The scientists studied 2568 craters at Descartes and 2543 craters at Taurus-Littrow in that size range." +
                    "The LROC scientists compared and catalogued the shape of small craters to better understand how erosion takes place in the top few meters of the regolith (soil). They grouped the craters into three basic classes. \"A\" craters are the least degraded, with sharp rims and bowl-shaped interiors. \"C\" craters are the most degraded, with no rims and shallow, funnel-shaped profiles. \"B\" craters fall in-between.They have rims lower than \"A\" craters and are more bowl-shaped than \"C\" craters.The shapes indicate how much erosion has taken place.",
                    Image = @"https://dnastore.blob.core.windows.net/product-image-asset-blob/TaurusLittrowValley.png"
				},
                new Product
                {
                    ID = 8,
                    Sku = "Lumi/Crat/MPS",
                    Name = "Luminous Pierazzo Crater",
                    Price = 1.45m,
                    Description = "This lunar farside rayed crater imaged by NASA's Lunar Reconnaissance Orbiter is named after planetary scientist Elisabetta “Betty” Pierazzo (1963-2011). Betty studied impact cratering, including the production of impact melt, so this 5.8-mile (9.3 kilometer) diameter crater with abundant impact melt was well chosen to honor Pierazzo. It is located within the north-northwestern extent of ejecta surrounding the Orientale impact basin." +
                    "This oblique image was acquired late in 2017, and required the spacecraft to roll 65° towards the limb; due to the curvature of the Moon, the viewing angle of the crater is actually 74°. This geometry is similar to viewing the distant landscape out of an airplane window, except that the Moon does not have an atmosphere that results in the hazy distant views seen on Earth.The opening image shows a reduced-scale view of the bright crater cavity and some of the ejecta.There is dark material on the crater ejecta and interior with linear and flow-like patterns.This dark material consists of lunar rocks that were melted by the very high-speed impact event, flowed in places, and then froze into dark glassy deposits.",
                    Image = @"https://dnastore.blob.core.windows.net/product-image-asset-blob/LuminousPierazzoCrater.jpg"
				},
                new Product
                {
                    ID = 9,
                    Sku = "Warg/Crat/MPS",
                    Name = "Wargo Crater",
                    Price = 1.10m,
                    Description = "Wargo Crater is an 8.6-mile (13.8 km) diameter impact crater sitting on the northwest edge of Joule T crater, on the far side of the Moon. " +
                    "The formation of Wargo crater had a big impact on its surroundings.An asteroid measuring several thousand feet in diameter slammed into the steeply sloping rim of Joule T crater(24 miles or 38 km in diameter) at hyper - velocity(3 to 12 miles per second) forming a crater over 3,000 feet(914 meters) deep.Massive amounts of instant magma crested the lower eastern rim and spread across the floor of Joule T." +
                    "The crater is named in honor of NASA’s former chief exploration scientist, Michael Wargo.",
                    Image = @"https://dnastore.blob.core.windows.net/product-image-asset-blob/WargoCrater.jpg"
				},
                new Product
                {
                    ID = 10,
                    Sku = "Hell/Crat/MPS",
                    Name = "Hell Q Crater",
                    Price = 1.25m,
                    Description = "The Moon's Hell Q crater, as imaged by the Lunar Reconnaissance Orbiter Camera (LROC) camera aboard NASA's Lunar Reconnaissance Orbiter spacecraft, which is now studying the Moon. The crater is about two miles across (3.4 kilometers)." +
                    "Some details of the impact process are still not well known.However, LROC images of very young craters are giving scientists new insights!In this image one can see delicate black streamers that landed on top of the main ejecta deposit.Either the black material was ejected late in the process or had a relatively high ejecta angle, thus taking longer to go up and come down relative to the main body of ejecta.What is that black material ? Most likely it is impact melt that cooled so fast that most turned to glass rather than minerals.Right along the rim of the crater you can see small tongues of the black material, indicating that it was a fluid when emplaced(and now hardened into glass).Its low reflectance is caused by the light - absorbing properties of glass." +
                    "By the way, the crater takes its name from the Hungarian Astronomer Maximilian Hell, not that hot place.",
                    Image = @"https://dnastore.blob.core.windows.net/product-image-asset-blob/HellQCrater.png"
				}
            );
        }

        // Database Tables
        public DbSet<Product> Products { get; set; }
		public DbSet<Basket> Baskets { get; set; }
		public DbSet<BasketItem> BasketItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
    }
}
