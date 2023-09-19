import React, { useState, useMemo} from "react";
import './css/App.css';
import Login from './components/Login';
import { useQuery, gql } from "@apollo/client";
import Pagination from './components/Pagination';
//import VenuesList from "./components/VenuesList";

let PageSize = 10;

function App() {

const [loggedIn, setLoggedIn] = useState(false); // Store user authentication state
const [category, setCategory] = useState("Select Category") // Store category selected

const [currentPage, setCurrentPage] = useState(1); // Store page for pagination
const [venues, setVenues] = useState([]); // Store the list of venues


const currentTableData = useMemo(() => {
  if(venues.length !== 0){
    const firstPageIndex = (currentPage - 1) * PageSize;
    const lastPageIndex = firstPageIndex + PageSize;
    return venues.venuesByCategory.slice(firstPageIndex, lastPageIndex);
  }
}, [currentPage, venues]);
    
const handleLogin = () => {
  setLoggedIn(true);
};

//query to Graphql
const PRODUCTS_QUERY = gql`
{      
  venuesByCategory(categoryId: "${category}"){
    sourceId
    name
    category{      
      description
    }
    latitude
    longitude
    geolocationDegrees
  }
}
`;

const CATEGORY_QUERY = gql`
  {
    categories{
      id
      description
    }
  }
`;

let handleCategoryChange = (e) => {  
  setCategory(e.target.value); 
  setCurrentPage(1);
}

function DropDownCategories () {  
  const { data, loading, error } = useQuery(CATEGORY_QUERY);

  if (loading) return "Loading...";
  if (error) return <pre>{error.message}</pre>  

  return (
    <div class="dropdown">
      <select onChange={handleCategoryChange}>      
        <option value={"Select Category"}> -- Select Category -- </option>
        {data.categories.map((category) => <option key={category.id} value={category.id}>{category.description}</option>)}
      </select>
    </div>
  );
};


const VenuesList = () => {    
  const { data, loading, error } = useQuery(PRODUCTS_QUERY);

  if (loading) return "Loading...";
  if (error) return <pre>{error.message}</pre>  
  if (data.venuesByCategory.length === 0) return <div/>

  setVenues(data)
  
  return (
    <div class="list">
      <h2>Venues List:</h2>
      <table>
      <thead>
        <tr>
          <th>ID</th>
          <th>NAME</th>
          <th>CATEGORY</th>
          <th>LATITUDE</th>
          <th>LONGITUDE</th>
          <th>GEOLOCATION</th>
        </tr>
      </thead>
      <tbody>
        {currentTableData?.map(item => {
          return (
            <tr>
              <td>{item.sourceId}</td>
              <td>{item.name}</td>
              <td>{item.category.description}</td>
              <td>{item.latitude}</td>
              <td>{item.longitude}</td>
              <td>{item.geolocationDegrees}</td>
            </tr>
          );
        })}
      </tbody>
      </table>
      <Pagination
        className="pagination-bar"
        currentPage={currentPage}
        totalCount={data.venuesByCategory.length}
        pageSize={PageSize}
        onPageChange={page => setCurrentPage(page)}
      />
    </div>
  );
};

return (  
    <div className="App">    
      {loggedIn ? (    
        <>        
          <DropDownCategories />         
          <VenuesList />                       
        </>
      ) : (
        <Login onLogin={handleLogin} />
      )}    
    </div>
  );
}

export default App;