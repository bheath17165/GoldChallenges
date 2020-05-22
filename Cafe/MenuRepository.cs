using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe
{
    public class MenuRepository
    {
        private List<Menu> _menuDirectory = new List<Menu>();

        public bool CreateItem(Menu item)
        {
            int startingCount = _menuDirectory.Count;

            _menuDirectory.Add(item);

            bool wasAdded = _menuDirectory.Count == startingCount + 1;

            return wasAdded;
        }

        public Menu GetItemByNumber(int number)
        {
            foreach (Menu menu in _menuDirectory)
            {
                if (menu.MealNumber == number)
                {
                    return menu;
                }
            }
            return null;
        }

        public bool DeleteItem(int number)
        {
            Menu content = GetItemByNumber(number);

            if (content == null)
            {
                Console.WriteLine("There is no Menu Item for that number.");
                return false;
            }
            else
            {
                _menuDirectory.Remove(content);
                return true;
            }
        }

        public List<Menu> GetListOfItems()
        {
            return _menuDirectory;
        }
    }
}
