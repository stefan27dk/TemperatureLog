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
               <iframe src="https://leanheat.com" class="iframeApp"></iframe>
          `;
      }



    // View Script ====================================================>
    async executeViewScript()
    {
        document.getElementById('viewTitle').innerText = 'Posts';
    }

}