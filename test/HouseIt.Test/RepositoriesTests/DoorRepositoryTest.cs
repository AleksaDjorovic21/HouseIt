// using HouseIt.Core.Domain;
// using HouseIt.Infrastructure.Persistence;
// using HouseIt.Infrastructure.Repositories;
// using HouseIt.Test.RepositoriesTests;

// namespace HouseIt.Tests.RepositoriesTests;

// public class DoorRepositoryTest : RepositoryTestBase
// {
//     [Fact]
//     public async Task AddAsync_ShouldAddDoor()
//     {
//         // Arrange
//         using var context = new HouseItDbContext(_options);
//         var repository = new DoorRepository(context);
//         var door = new Door(DoorType.Double, ColorPalette.White) { Id = 1 };

//         // Act
//         await repository.AddAsync(door);
//         var addedDoor = await context.Doors.FindAsync(1);

//         // Assert
//         Assert.NotNull(addedDoor);
//         Assert.Equal(DoorType.Double, addedDoor.Type);
//         Assert.Equal(ColorPalette.White, addedDoor.Color);
//     }

//     [Fact]
//     public async Task GetAllAsync_ShouldReturnAllDoors()
//     {
//         // Arrange
//         using (var context = new HouseItDbContext(_options))
//         {
//             context.Doors.AddRange(new List<Door>
//                 {
//                     new(DoorType.Double, ColorPalette.White) { Id = 1 },
//                     new(DoorType.Single, ColorPalette.Blue) { Id = 2 }
//                 });
//             await context.SaveChangesAsync();
//         }

//         // Act & Assert
//         using (var context = new HouseItDbContext(_options))
//         {
//             var repository = new DoorRepository(context);
//             var doors = await repository.GetAllAsync();

//             Assert.Equal(2, doors.Count());
//         }
//     }

//     [Fact]
//     public async Task GetByIdAsync_ShouldReturnDoor()
//     {
//         // Arrange
//         using (var context = new HouseItDbContext(_options))
//         {
//             context.Doors.Add(new Door(DoorType.Double, ColorPalette.White) { Id = 1 });
//             await context.SaveChangesAsync();
//         }

//         // Act & Assert
//         using (var context = new HouseItDbContext(_options))
//         {
//             var repository = new DoorRepository(context);
//             var door = await repository.GetByIdAsync(1);

//             Assert.NotNull(door);
//             Assert.Equal(DoorType.Double, door.Type);
//             Assert.Equal(ColorPalette.White, door.Color);
//         }
//     }

//     [Fact]
//     public async Task UpdateAsync_ShouldUpdateDoor()
//     {
//         // Arrange
//         using (var context = new HouseItDbContext(_options))
//         {
//             context.Doors.Add(new Door(DoorType.Double, ColorPalette.White) { Id = 1 });
//             await context.SaveChangesAsync();
//         }

//         // Act & Assert
//         using (var context = new HouseItDbContext(_options))
//         {
//             var repository = new DoorRepository(context);
//             var updatedDoor = new Door(DoorType.Double, ColorPalette.White) { Id = 1 };

//             await repository.UpdateAsync(updatedDoor);
//             var door = await context.Doors.FindAsync(1);

//             Assert.NotNull(door);
//             Assert.Equal(DoorType.Double, door.Type);
//             Assert.Equal(ColorPalette.White, door.Color);
//         }
//     }

//     [Fact]
//     public async Task DeleteAsync_ShouldDeleteDoor()
//     {
//         // Arrange
//         using (var context = new HouseItDbContext(_options))
//         {
//             context.Doors.Add(new Door(DoorType.Double, ColorPalette.White) { Id = 1 });
//             await context.SaveChangesAsync();
//         }

//         // Act & Assert
//         using (var context = new HouseItDbContext(_options))
//         {
//             var repository = new DoorRepository(context);
//             await repository.DeleteAsync(1);
//             var door = await context.Doors.FindAsync(1);

//             Assert.Null(door);
//         }
//     }
// }

