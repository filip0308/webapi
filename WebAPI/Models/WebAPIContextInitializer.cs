using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class WebAPIContextInitializer :DropCreateDatabaseAlways<WebAPIContext>
    {

        protected override void Seed(WebAPIContext context)
        {
            var hotdogs = new List<HotDog>
            {
                new HotDog()
                {
                    HotDogId = 1,
                    Name = "Regular Hot Dog",
                    ShortDescription = "The best there is on this planet",
                    Description = "Manchego smelly cheese danish fontina. Hard cheese cow goat red leicester pecorino macaroni cheese cheesecake gouda. Ricotta fromage cheese and biscuits stinking bishop halloumi monterey jack cheese strings goat. Pecorino babybel pecorino jarlsberg cow say cheese cottage cheese.",
                    ImagePath = "hotdog1",
                    Available = true,
                    PrepTime= 10,
                    Price = 15,
                    IsFavorite = true
                },
                new HotDog()
                {
                    HotDogId = 2,
                    Name = "Haute Dog",
                    ShortDescription = "The classy one",
                    Description = "Bacon ipsum dolor amet turducken ham t-bone shankle boudin kevin. Hamburger salami pork shoulder pork chop. Flank doner turducken venison rump swine sausage salami sirloin kielbasa pork belly tail cow. Pork chop bacon ground round cupim tongue, venison frankfurter bresaola tri-tip andouille sirloin turducken spare ribs biltong. Drumstick ham hock pork tail, capicola shank frankfurter beef ribs jowl meatball turkey hamburger. Tenderloin swine ham pork belly beef ribeye. ",
                    ImagePath = "hotdog2",
                    Available = true,
                    PrepTime= 10,
                    Price = 8,
                    IsFavorite = true
                },
                new HotDog()
                {
                    HotDogId = 3,
                    Name = "Extra Long",
                    ShortDescription = "For when a regular one isn't enough",
                    Description = "Capicola short loin shoulder strip steak ribeye pork loin flank cupim doner pastrami. Doner short loin frankfurter ball tip pork belly, shank jowl brisket. Kielbasa prosciutto chuck, turducken brisket short ribs tail pork shankle ball tip. Pancetta jerky andouille chuck salami pastrami bacon pig tri-tip meatball tail bresaola shank short ribs strip steak. Ham hock frankfurter ball tip, biltong cow pastrami swine tenderloin ground round pork loin t-bone. ",
                    ImagePath = "hotdog3",
                    Available = true,
                    PrepTime= 10,
                    Price = 12,
                    IsFavorite = true
                },
                new HotDog()
                    {
                        HotDogId = 4,
                        Name = "Veggie Hot Dog",
                        ShortDescription = "American for non-meat-lovers",
                        Description = "Veggies es bonus vobis, proinde vos postulo essum magis kohlrabi welsh onion daikon amaranth tatsoi tomatillo melon azuki bean garlic.\n\nGumbo beet greens corn soko endive gumbo gourd. Parsley shallot courgette tatsoi pea sprouts fava bean collard greens dandelion okra wakame tomato. Dandelion cucumber earthnut pea peanut soko zucchini.",
                        ImagePath = "hotdog4",
                        Available = true,
                        PrepTime= 15,
                        Price = 10,
                        IsFavorite = true
                    }
            };
            hotdogs.ForEach(b => context.HotDogs.Add(b));
            context.SaveChanges();

            base.Seed(context);
        }
    }
}