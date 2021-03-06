using System.Collections.Generic;

namespace BestRestaurants.Models
{
  public class Restaurant
  {
    public Restaurant()
    {
      this.JoinEntities = new HashSet<CuisineRestaurant>();
      this.Reviews = new HashSet<Review>();
    }
    public int RestaurantId { get; set; }
    public string Name { get; set; }
    public string City { get; set; }
    public string Price { get; set; }
    public virtual ICollection<CuisineRestaurant> JoinEntities{ get; }
    public virtual ICollection<Review> Reviews { get; set; }
  }
}