from django.urls import path, include
from rest_framework.authtoken.views import obtain_auth_token

from .views import NewsListView, NewsListCreate, ReviewCreateView



urlpatterns = [
    path('news/', NewsListView.as_view()),
    path('create_news/', NewsListCreate.as_view()),
    path('create_review/', ReviewCreateView.as_view()),
]