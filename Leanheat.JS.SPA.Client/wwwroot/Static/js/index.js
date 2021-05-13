// Imports
import Dashboard from "./views/Dashboard.js";
import Posts from "./views/Posts.js";
import Settings from "./views/Settings.js";
import Register from "./views/Register.js";
import Login from "./views/Login.js";
import Profile from "./views/Profile.js";


// Navigator--------------------------------------------------------------------------------->
const navigateTo = url => {
     history.pushState(null, null, url); // Add the url to the history APi of Js
     router();
};

//window.navigate = navigateTo; 


// Router------------------------------------------------------------------------------------>
 const router = async () => {
 const routes = [
   {path: "/", view: Dashboard}, // On Path "/" use the dashboard class and inject html in the #app div
   {path: "/posts", view: Posts },
   {path: "/settings", view: Settings },
   {path: "/Register", view: Register },
   {path: "/Login", view: Login },
   {path: "/Profile", view: Profile }
 ];

 

    

 // Test each route for potential match ----------------------------------------------------->
 // Get the current Url and check if its defined in routes method "Check if its one of our Spa Urls" ----------------------------------------------------->
 const potentialMatches = routes.map(route => {
  return {
      route: route,
      isMatch: location.pathname === route.path  // True if match else false - location.pathname = the path of the current page / View
  };
 });


        
     
 

// Check if there is Match------------------------------------------------------------------->
    let match = potentialMatches.find(potentialMatch => potentialMatch.isMatch);  // Get isMatch from potentialMatches


 // If no match return to StartPage
 if(!match)
 {
     match = {
     route: routes[0],
     isMatch: true
     };
 }

     


 const view = new match.route.view(); // If match  use the routes array of the router and get the view function for the route

 document.querySelector("#app").innerHTML = await view.getHtml();  // Get the #app div and use the view function to inject Html in it from the view class ex."Dashboard, Posts, Settings etc."
    await view.executeViewScript(); 
};





// On-Navigating-Back&Forth-Load the Content--Together with the url------------------------------------------------------------------------------------>
window.addEventListener("popstate", router); // On popstate "If back button is pressed" use the router array to load back the previeous SPA View


// Listen to document fully Loaded
document.addEventListener("DOMContentLoaded", () => {
  document.body.addEventListener("click", e => { //Listen for click in the body
    if(e.target.matches("[data-link]")){  // If body item was clicked and its data-link decorated
        e.preventDefault();  // Prevent deafult behavior dont follow the link
        navigateTo(e.target.href);  // Navigate method   
    }
  });


router(); // Load the content if the url is defined in our "Spa Urls"
});

//#### Client Routing END #####









