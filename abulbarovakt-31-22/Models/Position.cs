
using System.Text.RegularExpressions;
namespace abulbarovakt_31_22.Models

{
    public class Position
    {
        public int PositionId { get; set; }

        public string PositionName { get; set; }
        public bool isValidPositionName()
        {
            return Regex.Match(PositionName, @"^[А-ЯЁ][а-яё]*(\s[а-яё]+)*$").Success;
        }
    }
}
