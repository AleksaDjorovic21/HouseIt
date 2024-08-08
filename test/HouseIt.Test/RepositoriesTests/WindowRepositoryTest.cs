// using HouseIt.Core.Domain;
// using HouseIt.Infrastructure.Persistence;
// using HouseIt.Infrastructure.Repositories;
// using HouseIt.Test.RepositoriesTests;

// namespace HouseIt.Tests.RepositoriesTests;

// public class WindowRepositoryTest : RepositoryTestBase
// {
//     [Fact]
//     public async Task AddAsync_ShouldAddWindow()
//     {
//         // Arrange
//         using var context = new HouseItDbContext(_options);
//         var repository = new WindowRepository(context);
//         var window = new Window(WindowSizes.Large) { Id = 1 };

//         // Act
//         await repository.AddAsync(window);
//         var addedWindow = await context.Windows.FindAsync(1);

//         // Assert
//         Assert.NotNull(addedWindow);
//         Assert.Equal(WindowSizes.Large, addedWindow.Size);
//     }

//     [Fact]
//     public async Task GetAllAsync_ShouldReturnAllWindows()
//     {
//         // Arrange
//         using (var context = new HouseItDbContext(_options))
//         {
//             context.Windows.AddRange(new List<Window>
//                 {
//                     new(WindowSizes.Small) { Id = 1 },
//                     new(WindowSizes.Medium) { Id = 2 }
//                 });
//             await context.SaveChangesAsync();
//         }

//         // Act & Assert
//         using (var context = new HouseItDbContext(_options))
//         {
//             var repository = new WindowRepository(context);
//             var windows = await repository.GetAllAsync();

//             Assert.Equal(2, windows.Count());
//         }
//     }

//     [Fact]
//     public async Task GetByIdAsync_ShouldReturnWindow()
//     {
//         // Arrange
//         using (var context = new HouseItDbContext(_options))
//         {
//             context.Windows.Add(new Window(WindowSizes.Small) { Id = 1 });
//             await context.SaveChangesAsync();
//         }

//         // Act & Assert
//         using (var context = new HouseItDbContext(_options))
//         {
//             var repository = new WindowRepository(context);
//             var window = await repository.GetByIdAsync(1);

//             Assert.NotNull(window);
//             Assert.Equal(WindowSizes.Small, window.Size);
//         }
//     }

//     [Fact]
//     public async Task UpdateAsync_ShouldUpdateWindow()
//     {
//         // Arrange
//         using (var context = new HouseItDbContext(_options))
//         {
//             context.Windows.Add(new Window(WindowSizes.Small) { Id = 1 });
//             await context.SaveChangesAsync();
//         }

//         // Act & Assert
//         using (var context = new HouseItDbContext(_options))
//         {
//             var repository = new WindowRepository(context);
//             var updatedWindow = new Window(WindowSizes.Large) { Id = 1 };

//             await repository.UpdateAsync(updatedWindow);
//             var window = await context.Windows.FindAsync(1);

//             Assert.NotNull(window);
//             Assert.Equal(WindowSizes.Large, window.Size);
//         }
//     }

//     [Fact]
//     public async Task DeleteAsync_ShouldDeleteWindow()
//     {
//         // Arrange
//         using (var context = new HouseItDbContext(_options))
//         {
//             context.Windows.Add(new Window(WindowSizes.Small) { Id = 1 });
//             await context.SaveChangesAsync();
//         }

//         // Act & Assert
//         using (var context = new HouseItDbContext(_options))
//         {
//             var repository = new WindowRepository(context);
//             await repository.DeleteAsync(1);
//             var window = await context.Windows.FindAsync(1);

//             Assert.Null(window);
//         }
//     }
// }

