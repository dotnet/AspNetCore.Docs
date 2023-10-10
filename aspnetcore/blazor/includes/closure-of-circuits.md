<!-- UPDATE 8.0 Cross-link update -->

Interactive server components handle web UI events using a real-time connection with the browser called a circuit. A circuit and its associated state are created when a root interactive server component is rendered. The circuit is closed when there are no remaining interactive server components on the page, which frees up server resources.
