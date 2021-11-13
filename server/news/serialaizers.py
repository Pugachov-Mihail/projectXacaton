from rest_framework import serializers

from review.models import Review
from .models import News


class ReviewCreateSerializers(serializers.ModelSerializer):
    """Список комментариев"""
    class Meta:
        model = Review
        fields = '__all__'



class NewsListSerializers(serializers.ModelSerializer):
    '''Список новостей '''
    review = ReviewCreateSerializers(many=True)
    class Meta:
        model = News
        fields = "__all__"


class NewsCreateSerializers(serializers.ModelSerializer):
    '''Список новостей '''
    class Meta:
        model = News
        fields = "__all__"