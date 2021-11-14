from django.urls import path, include
from .views import NewsListView, NewsListCreate, ReviewCreateView #, CreateUser



urlpatterns = [
    path('news/', NewsListView.as_view()),
    path('create_news/', NewsListCreate.as_view()),
    path('create_review/', ReviewCreateView.as_view()),
    path('api-auth', include('rest_framework.urls')),
    path('auth/', include('djoser.urls')),
 #   path('register/', CreateUser.as_view()),
]