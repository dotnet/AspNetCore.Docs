using MvcMusicStore.Models;

using System.Web.Mvc;

using System.Collections;

namespace MvcMusicStore.ViewModels {

    public class AlbumSelectListViewModel {

        public Album Album { get; private set; }

        public SelectList Artists { get; private set; }

        public SelectList Genres { get; private set; }

        public AlbumSelectListViewModel(Album album, 

                                        IEnumerable artists, 

                                        IEnumerable genres) {

            Album = album;

            Artists = new SelectList(artists, "ArtistID", "Name", album.ArtistId);

            Genres = new SelectList(genres, "GenreID", "Name", album.GenreId);

        }

    }

}