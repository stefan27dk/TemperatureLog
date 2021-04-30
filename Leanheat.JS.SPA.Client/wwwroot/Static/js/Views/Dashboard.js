// Imports
// Using the abstract class
import AbstractView from "./AbstractView.js";


// Class ###########################################################>
export default class extends AbstractView {

    // Constructor =================================================>
    constructor()
    {
        super(); // The abstract class Constructor "Base constructor"
        this.setTitle("Dashboard");
    }



      // Get Html ====================================================>
      async getHtml()
      {
          return `
                  <h1>DASHBOARD CONTENT -- Welcome back,................</h1> 
                  <p>Here is the Dahsboard !!!!!!!!!!</p>  
                  `;
      }
  
}