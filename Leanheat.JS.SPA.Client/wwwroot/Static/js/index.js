// Imports
import Dashboard from "./views/Dashboard.js";
import Posts from "./views/Posts.js";
import Settings from "./views/Settings.js";


// Navigator--------------------------------------------------------------------------------->
const navigateTo = url => {
  history.pushState(null, null, url);
  router();
};

                       

// Router------------------------------------------------------------------------------------>
const router = async () => {
 const routes = [
   {path: "/", view: Dashboard}, // On Path "/" use the dashboard class and inject html
   {path: "/posts", view: Posts },
   {path: "/settings", view: Settings }
 ];

 

 

 // Test each route for potential match ----------------------------------------------------->
 const potentialMatches = routes.map(route => {
  return {
      route: route,
      isMatch: location.pathname === route.path
  };
 });




// Check if there is Match------------------------------------------------------------------->
 let match = potentialMatches.find(potentialMatch => potentialMatch.isMatch);


 // if no match return to StartPage
 if(!match)
 {
     match = {
     route: routes[0],
     isMatch: true
     };
 }

 const view = new match.route.view();

 document.querySelector("#app").innerHTML = await view.getHtml();
 
};





// On-Navigating-Back&Forth-Load the Content--Together with the url------------------------------------------------------------------------------------>
window.addEventListener("popstate", router);


// Listen to document fully Loaded
document.addEventListener("DOMContentLoaded", () => {
  document.body.addEventListener("click", e => { //Listen for the body
    if(e.target.matches("[data-link]")){  // If body item was clicked and its data-link decorated
      e.preventDefault();  // Prevent deafult behavior dont follow the link
      navigateTo(e.target.href);  // Navigate method
    }
  });


router();
});