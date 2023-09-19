import React, { useState, useMemo, useContext  } from 'react';
import { useQuery, gql } from "@apollo/client";
import Pagination from './Pagination';
import MyContext from '../App';

let PageSize = 10;

const VenuesList = () => {  
  const {category, setCategory} = useContext(MyContext);   

  //query to Graphql
  const PRODUCTS_QUERY = gql`
    {      
      venuesByCategory(categoryId: "${category}"){
        id
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

const { data, loading, error } = useQuery(PRODUCTS_QUERY);    
const [currentPage, setCurrentPage] = useState(1); // Store page for pagination

const currentTableData = useMemo((data) => { 
  if(data !== undefined || data === null) {
    const firstPageIndex = (currentPage - 1) * PageSize;
    const lastPageIndex = firstPageIndex + PageSize;
    return data.venuesByCategory.slice(firstPageIndex, lastPageIndex);  
  }
}, [currentPage]);
  

  if (loading) return "Loading...";
  if (error) return <pre>{error.message}</pre>  
  if (data.venuesByCategory.length === 0) return <div/>
  
    return (
      <div class>
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
                <td>{item.id}</td>
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

export default VenuesList;