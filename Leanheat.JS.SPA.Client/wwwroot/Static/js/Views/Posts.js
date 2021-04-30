// Imports
// Using the abstract class
import AbstractView from "./AbstractView.js";


// Class ###########################################################>
export default class extends AbstractView {

    // Constructor =================================================>
    constructor()
    {
        super(); // The abstract class Constructor "Base constructor"
        this.setTitle("Posts");
    }



      // Get Html ====================================================>
      async getHtml()
      {
          return `
                  <h1>Posts</h1>
                  <p>Here are the Posts !!!!!!!!!!</p>    
          `;
      }
  
}