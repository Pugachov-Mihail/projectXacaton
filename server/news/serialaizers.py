from rest_framework import serializers

from review.models import  Review
from .models import News


class ReviewCreateSerializers(serializers.ModelSerializer):
    """Список комментариев"""
    class Meta:
        model = Review
        fields = '__all__'



class NewsListSerializers(serializers.ModelSerializer):
    '''Список новостей '''

   # review = ReviewCreateSerializers(many=True)

    class Meta:
        model = News
        fields = ('id', 'title' ,'autor', 'news', 'text', 'date')
