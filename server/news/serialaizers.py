from rest_framework import serializers

from review.models import Review
from .models import News
from profileUser.models import UserProfil, UserFollowing, UserModel


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


class CreateUserSerializers(serializers.ModelSerializer):
    class Meta:
        model = UserModel
        fields = "__all__"


class UsersProfilSerializers(serializers.ModelSerializer):
    class Meta:
        model = UserProfil
        fields = "_all__"

class UserFollowingerSerializers(serializers.ModelSerializer):
    class Meta:
        model = UserFollowing
        fields = "_all__"