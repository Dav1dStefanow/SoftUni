using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P01.BookShopDatabase.Data.Models;

namespace P01.BookShopDatabase.Generators
{
    internal class CategoryGenerator
    {
        internal static Category[] CreateCategories()
        {
            string[] categoryNames = new string[]
            {
                "Science Fiction",
                "Drama",
                "Action",
                "Adventure",
                "Romance",
                "Mystery",
                "Horror",
                "Health",
                "Travel",
                "Children's",
                "Science",
                "History",
                "Poetry",
                "Comics",
                "Art",
                "Cookbooks",
                "Journals",
                "Biographies",
                "Fantasy",
            };

            int categoryCount = categoryNames.Length;

            Category[] categories = new Category[categoryCount];

            for (int i = 0; i < categoryCount; i++)
            {
                Category category = new Category()
                {
                    Name = categoryNames[i],
                };

                categories[i] = category;
            }

            return categories;
        }
    }
}
