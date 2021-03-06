using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using DatabaseFirstLINQ.Models;

namespace DatabaseFirstLINQ
{
    class Problems
    {
        private ECommerceContext _context;

        public Problems()
        {
            _context = new ECommerceContext();
        }
        public void RunLINQQueries()
        {
            //ProblemOne();
            //ProblemTwo();
            //ProblemThree();
            //ProblemFour();
            //ProblemFive();
            //ProblemSix();
            //ProblemSeven();
            //ProblemEight();
            //ProblemNine();
            //ProblemTen();
            //ProblemEleven();
            //ProblemTwelve();
            //ProblemThirteen();
            //ProblemFourteen();
            //ProblemFifteen();
            //ProblemSixteen();
            //ProblemSeventeen();
            //ProblemEighteen();
            //ProblemNineteen();
            //ProblemTwenty();
            //BonusOne();
            //BonusTwo();
            BonusThree();
        }

        // <><><><><><><><> R Actions (Read) <><><><><><><><><>
        private void ProblemOne()
        {
            // Write a LINQ query that returns the number of users in the Users table.
            // HINT: .ToList().Count

            var users = _context.Users;
            int numberOfUsers = 0;

            foreach (User user in users)
            {

                numberOfUsers++;
            }
            Console.WriteLine(numberOfUsers);
            Console.ReadLine();
        }

        private void ProblemTwo()
        {
            // Write a LINQ query that retrieves the users from the User tables then print each user's email to the console.
            var users = _context.Users;

            foreach (User user in users)
            {
                Console.WriteLine(user.Email);
            }
            Console.ReadLine();
        }

        private void ProblemThree()
        {
            // Write a LINQ query that gets each product where the products price is greater than $150.
            // Then print the name and price of each product from the above query to the console.

            var products = _context.Products;


            var productsUnder150 = products.Where(p => p.Price > 150);

            foreach (var product in productsUnder150)
            {
                Console.WriteLine(product.Name + " " + "Price:" + product.Price);
            }
            Console.ReadLine();
        }

        private void ProblemFour()
        {
            // Write a LINQ query that gets each product that contains an "s" in the products name.
            // Then print the name of each product from the above query to the console.

            var products = _context.Products;


            var productsWithS = products.Where(p => p.Name.Contains("s"));

            foreach (var product in productsWithS)
            {
                Console.WriteLine(product.Name);
            }
            Console.ReadLine();
        }

        private void ProblemFive()
        {
            // Write a LINQ query that gets all of the users who registered BEFORE 2016
            // Then print each user's email and registration date to the console.

            var users = _context.Users;

            DateTime yearToCheck = new DateTime(2016, 01, 01);

            var before2016 = users.Where(p => p.RegistrationDate < yearToCheck); ;

            foreach (User user in before2016)
            {
                Console.WriteLine(user.Email + "" + user.RegistrationDate);
            }
            Console.ReadLine();
        }

        private void ProblemSix()
        {
            // Write a LINQ query that gets all of the users who registered AFTER 2016 and BEFORE 2018
            // Then print each user's email and registration date to the console.

            var users = _context.Users;

            DateTime start = new DateTime(2016, 01, 01);
            DateTime end = new DateTime(2018, 01, 01);

            var before2016 = users.Where(p => p.RegistrationDate > start && p.RegistrationDate < end);

            foreach (User user in before2016)
            {
                Console.WriteLine(user.Email + "" + user.RegistrationDate);
            }
            Console.ReadLine();
        }

        // <><><><><><><><> R Actions (Read) with Foreign Keys <><><><><><><><><>

        private void ProblemSeven()
        {
            // Write a LINQ query that retreives all of the users who are assigned to the role of Customer.
            // Then print the users email and role name to the console.
            var customerUsers = _context.UserRoles.Include(ur => ur.Role).Include(ur => ur.User).Where(ur => ur.Role.RoleName == "Customer");
            foreach (UserRole userRole in customerUsers)
            {
                Console.WriteLine($"Email: {userRole.User.Email} Role: {userRole.Role.RoleName}");
            }
            Console.ReadLine();
        }

        private void ProblemEight()
        {
            // Write a LINQ query that retreives all of the products in the shopping cart of the user who has the email "afton@gmail.com".
            // Then print the product's name, price, and quantity to the console.

            var productsinCart = _context.ShoppingCarts.Include(sc => sc.Product).Include(sc => sc.User).Where(sc => sc.User.Email == "afton@gmail.com");
            foreach (ShoppingCart product in productsinCart)
            {
                Console.WriteLine(product.Product.Name + " " + product.Product.Price + " " + product.Quantity);
            }
            Console.ReadLine();
        }

        private void ProblemNine()
        {
            // Write a LINQ query that retreives all of the products in the shopping cart of the user who has the email "oda@gmail.com" and returns the sum of all of the products prices.
            // HINT: End of query will be: .Select(sc => sc.Product.Price).Sum();
            // Then print the total of the shopping cart to the console.

            var productsinCart = _context.ShoppingCarts.Include(sc => sc.Product).Include(sc => sc.User).Where(sc => sc.User.Email == "oda@gmail.com").Select(sc => sc.Product.Price).Sum();


            Console.WriteLine(productsinCart);


            Console.ReadLine();
        }

        private void ProblemTen()
        {
            // Write a LINQ query that retreives all of the products in the shopping cart of users who have the role of "Employee".
            // Then print the user's email as well as the product's name, price, and quantity to the console.

            var roleEmp = _context.UserRoles.Include(re => re.Role).Include(re => re.User).Where(re => re.Role.RoleName == "Employee").Select(ur => ur.UserId).ToList();
            var productsinCart = _context.ShoppingCarts.Include(sc => sc.Product).Include(sc => sc.User).Where(sc => roleEmp.Contains(sc.UserId)).ToList();


            foreach (ShoppingCart product in productsinCart)
            {
                Console.WriteLine(product.User.Email + " " + product.Product.Name + " " + product.Product.Price + " " + product.Quantity);
            }
            Console.ReadLine();
        }

        // <><><><><><><><> CUD (Create, Update, Delete) Actions <><><><><><><><><>

        // <><> C Actions (Create) <><>

        private void ProblemEleven()
        {
            // Create a new User object and add that user to the Users table using LINQ.
            User newUser = new User()
            {
                Email = "david@gmail.com",
                Password = "DavidsPass123"
            };
            _context.Users.Add(newUser);
            _context.SaveChanges();
        }

        private void ProblemTwelve()
        {
            // Create a new Product object and add that product to the Products table using LINQ.
            Product newProduct = new Product()
            {
                Name = "Chevrolet Corvet",
                Description = "Fast Car",
                Price = 50000
            };
            _context.Products.Add(newProduct);
            _context.SaveChanges();

           
        }

        private void ProblemThirteen()
        {
            // Add the role of "Customer" to the user we just created in the UserRoles junction table using LINQ.
            var roleId = _context.Roles.Where(r => r.RoleName == "Customer").Select(r => r.Id).SingleOrDefault();
            var userId = _context.Users.Where(u => u.Email == "david@gmail.com").Select(u => u.Id).SingleOrDefault();
            UserRole newUserRole = new UserRole()
            {
                UserId = userId,
                RoleId = roleId
            };
            _context.UserRoles.Add(newUserRole);
            _context.SaveChanges();
        }

        private void ProblemFourteen()
        {
            // Add the product you create to the user we created in the ShoppingCart junction table using LINQ.
            var productId = _context.Products.Where(p => p.Name == "Chevrolet Corvet").Select(p => p.Id).SingleOrDefault();
            var userId = _context.Users.Where(u => u.Email == "david@gmail.com").Select(u => u.Id).SingleOrDefault();
            ShoppingCart newShoppingCart = new ShoppingCart()
            {
                ProductId = productId,
                UserId = userId
            };

            _context.ShoppingCarts.Add(newShoppingCart);
            _context.SaveChanges();

        }

        // <><> U Actions (Update) <><>

        private void ProblemFifteen()
        {
            // Update the email of the user we created to "mike@gmail.com"
            var user = _context.Users.Where(u => u.Email == "david@gmail.com").SingleOrDefault();
            user.Email = "mike@gmail.com";
            _context.Users.Update(user);
            _context.SaveChanges();
        }

        private void ProblemSixteen()
        {
            // Update the price of the product you created to something different using LINQ.
            var prod = _context.Products.Where(p => p.Price == 50000).SingleOrDefault();
            prod.Price = 25000;
            _context.Products.Update(prod);
            _context.SaveChanges();


        }

        private void ProblemSeventeen()
        {
            // Change the role of the user we created to "Employee"
            // HINT: You need to delete the existing role relationship and then create a new UserRole object and add it to the UserRoles table
            // See problem eighteen as an example of removing a role relationship
            var userRole = _context.UserRoles.Where(ur => ur.User.Email == "mike@gmail.com").SingleOrDefault();
            _context.UserRoles.Remove(userRole);
            UserRole newUserRole = new UserRole()
            {
                UserId = _context.Users.Where(u => u.Email == "mike@gmail.com").Select(u => u.Id).SingleOrDefault(),
                RoleId = _context.Roles.Where(r => r.RoleName == "Employee").Select(r => r.Id).SingleOrDefault()
            };
            _context.UserRoles.Add(newUserRole);
            _context.SaveChanges();
        }

        // <><> D Actions (Delete) <><>

        private void ProblemEighteen()
        {
            // Delete the role relationship from the user who has the email "oda@gmail.com" using LINQ.
            var userRole = _context.UserRoles.Where(ur => ur.User.Email == "oda@gmail.com").SingleOrDefault();
            _context.UserRoles.Remove(userRole);
            _context.SaveChanges();


        }

        private void ProblemNineteen()
        {
            // Delete all of the product relationships to the user with the email "oda@gmail.com" in the ShoppingCart table using LINQ.
            // HINT: Loop
            var shoppingCartProducts = _context.ShoppingCarts.Where(sc => sc.User.Email == "oda@gmail.com");
            foreach (ShoppingCart userProductRelationship in shoppingCartProducts)
            {
                _context.ShoppingCarts.Remove(userProductRelationship);
            }
            _context.SaveChanges();
        }

        private void ProblemTwenty()
        {
            // Delete the user with the email "oda@gmail.com" from the Users table using LINQ.
            var userToDelete = _context.Users.Where(u => u.Email == "oda@gmail.com").SingleOrDefault();
            _context.Users.Remove(userToDelete);
            _context.SaveChanges();


        }

        // <><><><><><><><> BONUS PROBLEMS <><><><><><><><><>

        private void BonusOne()
        {
            // Prompt the user to enter in an email and password through the console.
            // Take the email and password and check if the there is a person that matches that combination.
            // Print "Signed In!" to the console if they exists and the values match otherwise print "Invalid Email or Password.".

            var userEmail = "";
            var userPassword = "";

            Console.WriteLine("Please enter your email. ");
            userEmail = Console.ReadLine();
            Console.WriteLine("Please enter your password. ");
            userPassword = Console.ReadLine();

            var emailToCheck = _context.Users.Where(u => u.Email == userEmail && u.Password == userPassword).SingleOrDefault();

            if (emailToCheck != null)
            {
                Console.WriteLine("Signed In!");
            }
            else
            {
                Console.WriteLine("Invalid Email or Password.");
            }
            
            Console.ReadLine();
        }

        private void BonusTwo()
        {
            // Write a query that finds the total of every users shopping cart products using LINQ.
            // Display the total of each users shopping cart as well as the total of the totals to the console.
            var userIds = _context.Users.Select(u => u.Id).ToList();
            var productsinCart = _context.ShoppingCarts.Include(sc => sc.Product).Include(sc => sc.User);
            decimal totalAllCarts = 0;
            decimal totalUserCart = 0;
            string userEmail = "";
            

            foreach (int id in userIds)
            {
                foreach (ShoppingCart userCart in productsinCart)
                {
                    if(id == userCart.UserId)
                    {
                        totalUserCart += userCart.Product.Price;
                        totalAllCarts += userCart.Product.Price;
                        userEmail = userCart.User.Email;
                    }
                }
                Console.WriteLine("Customer with email:  " + userEmail +  " has a total balance of: " + totalUserCart);
                totalUserCart = 0;
                userEmail = "";
            }
            Console.WriteLine("The total shopping cart balance is : " + totalAllCarts);
            Console.ReadLine();
        }

        private void BonusThree()
        {
            // 1. Create functionality for a user to sign in via the console
            // 2. If the user succesfully signs in
            // a. Give them a menu where they perform the following actions within the console
            // View the products in their shopping cart
            // View all products in the Products table
            // Add a product to the shopping cart (incrementing quantity if that product is already in their shopping cart)
            // Remove a product from their shopping cart
            // 3. If the user does not succesfully sing in
            // a. Display "Invalid Email or Password"
            // b. Re-prompt the user for credentials

            var userEmail = "";
            var userPassword = "";
            string selection = "";
            int count = 1;
            string selectionTwo = "";

            Console.WriteLine("Please enter your email. ");
            userEmail = Console.ReadLine();
            Console.WriteLine("Please enter your password. ");
            userPassword = Console.ReadLine();

            var emailToCheck = _context.Users.Where(u => u.Email == userEmail && u.Password == userPassword).SingleOrDefault();

            if (emailToCheck != null)
            {
                Console.WriteLine("Signed In!");

                Console.WriteLine("Select [1] to View Shopping Cart \r\n" +
                                  "Select [2] to View ALL Products \r\n" +
                                  "Select [3] to  ADD Products \r\n" +
                                  "Select [4] to REMOVE a Product");
                selection = Console.ReadLine();

                switch (selection)
                {
                    case "1": 
                         var custShopCart = _context.ShoppingCarts.Include(sc => sc.Product).Include(sc => sc.User).Where(sc => sc.User.Email == userEmail);
                         foreach(ShoppingCart item in custShopCart)
                         {
                            Console.WriteLine(item.Product.Name + " " + item.Product.Price);
                         }
                         Console.ReadLine();
                        break;
                    case "2":
                        
                        var allProducts = _context.Products;
                        foreach (Product item in allProducts)
                        {
                            Console.WriteLine( count + " " + item.Name + " " + item.Price);
                            count++;
                        }
                        count = 0;
                        Console.ReadLine();
                        break;
                    case "3":
                        Console.WriteLine("Select [1] to Add Gazelle 22272 T4 Pop-Up \r\n" +
                                  "Select [2] to View ALL Products \r\n" +
                                  "Select [3] to  ADD Products \r\n" +
                                  "Select [4] to REMOVE a Product");
                        selectionTwo = Console.ReadLine();

                        switch(selectionTwo)
                        {
                            case "1":
                                var productToAdd = _context.Products.Where(p => p.Name == "Gazelle 22272 T4 Pop - Up").Select(p => p.Id).SingleOrDefault();
                                var LoggedInUserId = _context.Users.Where(u => u.Email == userEmail).Select(u => u.Id).SingleOrDefault();
                                ShoppingCart newShoppingCartAdd = new ShoppingCart()
                                {
                                    UserId = LoggedInUserId,
                                    ProductId = productToAdd
                                };
                                _context.ShoppingCarts.Add(newShoppingCartAdd);
                                _context.SaveChanges();
                                break;
                            case "2":
                                var productToAdd2 = _context.Products.Where(p => p.Name == "Freedom from the Known - Jiddu Krishnamurti").Select(p => p.Id).SingleOrDefault();
                                var LoggedInUserId2 = _context.Users.Where(u => u.Email == userEmail).Select(u => u.Id).SingleOrDefault();
                                ShoppingCart newShoppingCartAdd2 = new ShoppingCart()
                                {
                                    UserId = LoggedInUserId2,
                                    ProductId = productToAdd2
                                };
                                _context.ShoppingCarts.Add(newShoppingCartAdd2);
                                _context.SaveChanges();
                                break;
                            case "3":
                                var productToAdd3 = _context.Products.Where(p => p.Name == "Ball Mason Jar-32 oz.").Select(p => p.Id).SingleOrDefault();
                                var LoggedInUserId3 = _context.Users.Where(u => u.Email == userEmail).Select(u => u.Id).SingleOrDefault();
                                ShoppingCart newShoppingCartAdd3 = new ShoppingCart()
                                {
                                    UserId = LoggedInUserId3,
                                    ProductId = productToAdd3
                                };
                                _context.ShoppingCarts.Add(newShoppingCartAdd3);
                                _context.SaveChanges();
                                break;
                            case "4":
                                var productToAdd4 = _context.Products.Where(p => p.Name == "Stellar Basic Flute Key of G - Native American Style Flute").Select(p => p.Id).SingleOrDefault();
                                var LoggedInUserId4 = _context.Users.Where(u => u.Email == userEmail).Select(u => u.Id).SingleOrDefault();
                                ShoppingCart newShoppingCartAdd4 = new ShoppingCart()
                                {
                                    UserId = LoggedInUserId4,
                                    ProductId = productToAdd4
                                };
                                _context.ShoppingCarts.Add(newShoppingCartAdd4);
                                _context.SaveChanges();
                                break;
                            case "5":
                                var productToAdd5 = _context.Products.Where(p => p.Name == "Catan The Board Game").Select(p => p.Id).SingleOrDefault();
                                var LoggedInUserId5 = _context.Users.Where(u => u.Email == userEmail).Select(u => u.Id).SingleOrDefault();
                                ShoppingCart newShoppingCartAdd5 = new ShoppingCart()
                                {
                                    UserId = LoggedInUserId5,
                                    ProductId = productToAdd5
                                };
                                _context.ShoppingCarts.Add(newShoppingCartAdd5);
                                _context.SaveChanges();
                                break;
                            case "6":
                                var productToAdd6 = _context.Products.Where(p => p.Name == "Apple Watch Series 3").Select(p => p.Id).SingleOrDefault();
                                var LoggedInUserId6 = _context.Users.Where(u => u.Email == userEmail).Select(u => u.Id).SingleOrDefault();
                                ShoppingCart newShoppingCartAdd6 = new ShoppingCart()
                                {
                                    UserId = LoggedInUserId6,
                                    ProductId = productToAdd6
                                };
                                _context.ShoppingCarts.Add(newShoppingCartAdd6);
                                _context.SaveChanges();
                                break;
                            case "7":
                                var productToAdd7 = _context.Products.Where(p => p.Name == "Nintendo Switch").Select(p => p.Id).SingleOrDefault();
                                var LoggedInUserId7 = _context.Users.Where(u => u.Email == userEmail).Select(u => u.Id).SingleOrDefault();
                                ShoppingCart newShoppingCartAdd7 = new ShoppingCart()
                                {
                                    UserId = LoggedInUserId7,
                                    ProductId = productToAdd7
                                };
                                _context.ShoppingCarts.Add(newShoppingCartAdd7);
                                _context.SaveChanges();
                                break;
                            case "8":
                                var productToAdd8 = _context.Products.Where(p => p.Name == "Chevrolet Corvet").Select(p => p.Id).SingleOrDefault();
                                var LoggedInUserId8 = _context.Users.Where(u => u.Email == userEmail).Select(u => u.Id).SingleOrDefault();
                                ShoppingCart newShoppingCartAdd8 = new ShoppingCart()
                                {
                                    UserId = LoggedInUserId8,
                                    ProductId = productToAdd8
                                };
                                _context.ShoppingCarts.Add(newShoppingCartAdd8);
                                _context.SaveChanges();
                                break;
                            default:
                                break;
                        }

                        break;
                    case "4":
                        break;
                    default:
                        Console.WriteLine("Invalid Selection, Try Again.");
                        break;
                }
            }

            else
            {
                Console.WriteLine("Invalid Email or Password.");
            }

            Console.ReadLine();
        }

    }
   
}

