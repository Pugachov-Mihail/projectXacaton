from django.contrib.auth.models import User
from rest_framework import serializers

from review.models import Review
from .models import News
from profileUser.models import UserProfil, UserFollowing


class NewsCreateSerializers(serializers.ModelSerializer):
    '''Создание новости '''
    class Meta:
        model = News
        fields = "__all__"


class CreateUserSerializers(serializers.ModelSerializer):
    """Создание пользователя"""
    password2 = serializers.CharField()
    email = serializers.EmailField()
    username = serializers.CharField()

    class Meta:
        model = User
        fields = ['email', 'username', 'password', 'password2', 'first_name', 'last_name']

    def save(self, **kwargs):
        user = User(
            email=self.validated_data['email'],
            username=self.validated_data['username'])
        password = self.validated_data['password']
        password2 = self.validated_data['password2']
        if password != password2:
            raise serializers.ValidationError({password: "Пароли не совпадают"})
        user.set_password(password)
        user.save()
        return user


class UsersProfilSerializers(serializers.ModelSerializer):
    """Новости и комментарии пользователя"""
    class Meta:
        model = UserProfil
        fields = "__all__"

class UserFollowingerSerializers(serializers.ModelSerializer):
    """Подписчики"""
    class Meta:
        model = UserFollowing
        fields = "__all__"

class Users(serializers.ModelSerializer):
    username = serializers.CharField()
    first_name = serializers.CharField()
    last_name = serializers.CharField()
    class Meta:
        model = User
        fields = ['username', 'first_name', 'last_name']


class ReviewCreateSerializers(serializers.ModelSerializer):
    """Список комментариев"""
    user = Users()
    class Meta:
        model = Review
        fields = '__all__'



class NewsListSerializers(serializers.ModelSerializer):
    '''Список новостей '''
    review = ReviewCreateSerializers(many=True)
    user = Users()
    class Meta:
        model = News
        fields = "__all__"
