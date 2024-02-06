## Task for theme REST API

Create a REST API application that handles requests witn next paths:   
•	'/Checkout' - POST request  
•	'/Products'- GET and POST requests  
•   '/Products/\{index}'- GET, PUT and DELETE requests
 
CheckoutController and ProductsController should handle the requests.

### CheckoutController:

 - Should use ICartService, IPaymentService IShipmentService as a dependencies.
 - Has one action *ConductCheckout* that handles POST requests.  
     If Charge method of CartService returns true, the Ship method of ShipmentService sould be called and a result of this mentod should be returned from ConductCheckout.
     Otherwise, "not charged" should be returned

 - ICartService should define and CartService should implement 2 methods:
     - TotalSum - returns total price sum of cart items
     - TotalQuantity - returns total quantity of products
     Both take IEnumerable<CartItem> as an argument
 - IPaymentService should define and PaymentService should implement method
     - Charge, takes 2 arguments - decimal - total price to pay, and Card.  
     The method returns true if expiration date of a card did not pass, otherwise returns false.
 - IShipmentService should define and ShipmentService should implement method
     - Ship - takes AddressInfo info and IEnumerable<CartItem> items as arguments.
     Returns string with the next format:
     ```Shipped <quantity> items to  <City> on total sum <total sum>```  
     ShipmentService should use CartService as a dependency, and call TotalSum and TotalQuantity methods in Ship method.
  
### ProductsController:
- Should use IDataProviderService as a dependency.
- Has actions Get, Post, Update and Delete. You should fill in missing parts in those actions
