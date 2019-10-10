# UWP-SplitView-Navigation
Demonstrates building a navigation menu in a MVVM XAML UWP app with guidelines-compatible
* Menu's
* Icons
* Back button
* Theming

If facing memory leak issues in UWP apps occuring due to split pane navigation, below are the steps for reproducing:
* Occurs when using split pane with system default back button or custom back button
* Have greater effect when using pages with heavier content like html or image loaders
Steps to avoid them: 
* Unsubscribe the self subscribed event handlers from code:
    Loaded += OnLoaded; (when page is loaded)
    Loaded -= OnLoaded; (when page is disappearing)
* Clear image cache by disabling the cache on images or use bitmap images for faster load
* Clear scripts of html viewer and dispose the unnecessary objects on unload event
    


More info here: https://xamlbrewer.wordpress.com/2017/02/06/building-splitview-navigation-in-uwp/
