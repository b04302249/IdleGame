package server.repository;


import org.springframework.data.jpa.repository.JpaRepository;
import server.User;

import java.util.Optional;

public interface UserRepository extends JpaRepository<User, Long> {

    Optional<User> findUserById(Long id);

    Optional<User> findUserByUserName(String userName);
}
