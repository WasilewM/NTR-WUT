import { Counter } from "./components/Counter";
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
    path: '/books',
    element: <BooksList/>
  }
];

export default AppRoutes;
