import { Counter } from "./components/Counter";
import { BookDetails } from "./components/BookDetails";
import { MyReservations } from "./components/MyReservations";
import { MyRentals } from "./components/MyRentals";
import { BooksList } from "./components/BooksList";
import { Home } from "./components/Home";

const AppRoutes = [
  {
    index: true,
    element: <Home />
  },
  {
    path: '/counter',
    element: <Counter />
  },
  {
    path: '/my-reservations',
    element: <MyReservations/>
  },
  {
    path: '/my-rentals',
    element: <MyRentals/>
  },
  {
    path: '/books',
    element: <BooksList/>
  },
  {
    path: '/book-details',
    element: <BookDetails/>
  }
];

export default AppRoutes;
