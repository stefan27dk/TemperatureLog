// Imports
// Using the abstract class
import AbstractView from "./AbstractView.js";
//import { FetchPostsIframe } from "/static/js/resources/default_scripts.js";


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
                  <div id="postsIframe" class="iframe"></div>
          `;
      }



    // View Script ====================================================>
    async executeViewScript()
    {
        //var a = await FetchPostsIframe('https://leanheat.com/').then(text => { return text });
        //let iframePost = document.getElementById('postsIframe');
        //iframePost.innerHTML = a;
         
    }

}