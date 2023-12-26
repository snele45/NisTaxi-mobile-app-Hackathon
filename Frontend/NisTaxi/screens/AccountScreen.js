import { StatusBar } from 'expo-status-bar';
import { StyleSheet, Text, View, ScrollView, Image, Button, Pressable } from 'react-native';
import QRCode from 'react-native-qrcode-svg';
import QRCodeStyled from 'react-native-qrcode-styled';
import { useContext } from 'react';
import { AuthContext } from '../context/AuthContext';

export default function ReceiptsScreen() {

  const { logout } = useContext(AuthContext);

  return (
    <View style={styles.container}>
      <ScrollView showsVerticalScrollIndicator={false} showsHorizontalScrollIndicator={false} style={styles.scrollView}>
      <View style={{flex: 1, justifyContent: 'center', alignItems: 'center'}}>
        <Text style={styles.nameText}>Petar Petrovic</Text>
      </View>
    
        <View style={{flex: 1, justifyContent: 'center', alignItems: 'center'}}>
          <Pressable style={styles.shareBtn} onPress={() => logout()}>
            <Text style={styles.shareBtnText}>Odjavi se</Text>
          </Pressable>
        </View>
        <StatusBar style="auto" />
      </ScrollView>
    </View>
  );
}

const styles = StyleSheet.create({
  container: {
    width: '100%',
    backgroundColor: '#fff',
    paddingLeft: 20,
    paddingRight: 20,
    paddingTop: 80,
    alignItems: 'center',
    justifyContent: 'center',
  },
  scrollView:{
    width: '100%',
  },
  root: {
    justifyContent: 'center',
    alignItems: 'center',
  },
  svg: {
    marginTop: 20,
    backgroundColor: '#fff',
    borderRadius: 20,
    overflow: 'hidden',
  },
  logoContainer: {
    position: 'absolute',
    width: 88,
    height: 88,
    backgroundColor: '#fff',
    justifyContent: 'center',
    alignItems: 'center',
  },
  logo: {
    width: '90%',
    height: '90%',
    top: -2,
  },
  userIcon:{
    width: 50,
    height: 50,
  },
  nameText:{
    fontSize: 22,
    fontWeight: '700',
    marginTop: 5,
  },
  fuelText:{
    fontSize: 15,
    fontWeight: '400',
    color: '#8F8F8F',
  },
  shareBtn:{
    marginTop: 40,
    alignItems: 'center',
    justifyContent: 'center',
    paddingVertical: 15,
    paddingHorizontal: 32,
    width: '100%',
    borderRadius: 4,
    elevation: 4,
    backgroundColor: '#F5BF24',
  },
  shareBtnText:{
    fontSize: 22,
    fontWeight: '700',
  },
  promotionsView:{
    marginTop: 40,
  },
  promotion:{
    marginTop: 20,
    width: '100%',
    height: 150,
    backgroundColor: '#F5BF24',
    borderRadius: 10,
  }
});
