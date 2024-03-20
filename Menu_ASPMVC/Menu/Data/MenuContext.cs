using Menu.Models;

using Microsoft.EntityFrameworkCore;

namespace Menu.Data;

public class MenuContext : DbContext {
	public MenuContext(DbContextOptions<MenuContext> options) : base(options) { }

	protected override void OnModelCreating(ModelBuilder modelBuilder) {
		modelBuilder.Entity<Dish>()
			.HasKey(d => d.Id);


		modelBuilder.Entity<Ingredient>()
			.HasKey(i => i.Id);

		modelBuilder.Entity<DishIngredient>()
			.HasKey(di => new { di.ContextDish, di.ContextIngredient });

		modelBuilder.Entity<DishIngredient>()
			.HasOne(di => di.ContextDish)
			.WithMany(d => d.Ingredients)
			.HasForeignKey(di => di.ContextDish);

		modelBuilder.Entity<DishIngredient>()
			.HasOne(di => di.ContextIngredient)
			.WithMany(i => i.DishIngredients)
			.HasForeignKey(di => di.ContextIngredient);

		SetupData(modelBuilder);

		base.OnModelCreating(modelBuilder);
	}

	private void SetupData(ModelBuilder modelBuilder) {
		var pizzaHolder = new Dish { Id = 1, Name = "Margeritta", Price = 7.50, ImageUrl = "https://katiespizza.com/cdn/shop/products/wood-fired-margherita-pizza_300x.jpg" };
		modelBuilder.Entity<Dish>().HasData(
			pizzaHolder
			);

		var IngredientHolder1 = new Ingredient { Id = 1, Name = "Tomato Sauce" };
		var IngredientHolder2 = new Ingredient { Id = 2, Name = "Mozzarella" };
		modelBuilder.Entity<Ingredient>().HasData(
			IngredientHolder1,
			IngredientHolder2
			);

		modelBuilder.Entity<DishIngredient>().HasData(
			new DishIngredient { ContextDish = pizzaHolder, ContextIngredient = IngredientHolder1 },
			new DishIngredient { ContextDish = pizzaHolder, ContextIngredient = IngredientHolder2 }
			);
	}

	public DbSet<Dish> dishes { get; set; }
	public DbSet<Ingredient> ingredients { get; set; }
	public DbSet<DishIngredient> dishIngredients { get; set; }
}
