using Microsoft.AspNetCore.Mvc.RazorPages;
using Proiect_Loredana.Data;
namespace Proiect_Loredana.Models
{
    public class GameCategoriesPageModel : PageModel
    {
        public List<AssignedCategoryData> AssignedCategoryDataList;
        public void PopulateAssignedCategoryData(Proiect_LoredanaContext context,
        Game Game)
        {
            var allCategories = context.Category;
            var GameCategories = new HashSet<int>(
            Game.GameCategories.Select(c => c.CategoryID)); //
            AssignedCategoryDataList = new List<AssignedCategoryData>();
            foreach (var cat in allCategories)
            {
                AssignedCategoryDataList.Add(new AssignedCategoryData
                {
                    CategoryID = cat.ID,
                    Name = cat.CategoryName,
                    Assigned = GameCategories.Contains(cat.ID)
                });
            }
        }
        public void UpdateGameCategories(Proiect_LoredanaContext context,
        string[] selectedCategories, Game GameToUpdate)
        {
            if (selectedCategories == null)
            {
                GameToUpdate.GameCategories = new List<GameCategory>();
                return;
            }
            var selectedCategoriesHS = new HashSet<string>(selectedCategories);
            var GameCategories = new HashSet<int>
            (GameToUpdate.GameCategories.Select(c => c.Category.ID));
            foreach (var cat in context.Category)
            {
                if (selectedCategoriesHS.Contains(cat.ID.ToString()))
                {
                    if (!GameCategories.Contains(cat.ID))
                    {
                        GameToUpdate.GameCategories.Add(
                        new GameCategory
                        {
                            GameID = GameToUpdate.ID,
                            CategoryID = cat.ID
                        });
                    }
                }
                else
                {
                    if (GameCategories.Contains(cat.ID))
                    {
                        GameCategory courseToRemove
                        = GameToUpdate
                        .GameCategories
                        .SingleOrDefault(i => i.CategoryID == cat.ID);
                        context.Remove(courseToRemove);
                    }
                }
            }
        }


    }
}
