from django.urls import path
from .views import NewsListView, ReviewCreateView


urlpatterns = [
    path('news/', NewsListView.as_view()),
    path('review/', ReviewCreateView.as_view()),
]